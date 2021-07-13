#!/bin/bash
# Check NordVPN user details
# https://blogsleeplessbeastie.wpcomstaging.com/2019/05/15/how-to-display-user-details-using-nordvpn-api/
# milosz at sleeplessbeastie.eu


# usage info
usage(){
  echo "Usage:"
  echo "  $0 -u username -p password"
  echo ""
  echo "Parameters:"
  echo "  -u username        : set username (required)"
  echo "  -p password        : set password (required)"
  echo ""
}

# parse parameters
while getopts "u:p:" option; do
  case $option in
    "u")
      param_username="${OPTARG}"
      param_username_defined=true
      ;;
    "p")
      param_password="${OPTARG}"
      param_password_defined=true
      ;;
    \?|:|*)
      usage
      exit
      ;;
  esac
done

if [ "${param_username_defined}" = true ] && \
   [ "${param_password_defined}" = true ]; then

  # get access token, key and salt
  access_json=$(curl --silent -X GET --header "Accept: application/json" "https://api.nordvpn.com/token/token/${param_username}")
  if [ "${access_json}" == "" ]; then echo "Error connecting to NordVPN service"; exit 1; fi

  # parse json to extract data
  access_token="$(echo $access_json | jq --raw-output '.token')"
  access_key="$(echo $access_json | jq --raw-output '.key')"
  access_salt="$(echo $access_json | jq --raw-output '.salt')"

  # compute access hash
  access_hash="$(echo -n "$(echo -n "${access_salt}${param_password}" | sha512sum - | cut -d " " -f1)${access_key}" | sha512sum - | cut -d " " -f1)"

  # verify credentials
  access_result="$(curl --silent -X GET --header "Accept: application/json" "https://api.nordvpn.com/token/verify/${access_token}/${access_hash}")"
  if [ "${access_result}" != "true" ]; then echo "Incorrect credentials"; exit 2; fi

  # get user data
  user_json="$(curl --silent -X GET --header "nToken: ${access_token}" --header "Accept: application/json" "https://api.nordvpn.com/user/databytoken")"
  if [ "${user_json}" == "" ]; then echo "Error connecting to NordVPN service using token"; exit 3; fi

  # parse json to extract user data
  user_trial="$(echo $user_json | jq --raw-output '.trial')"
  user_expires="$(echo $user_json | jq --raw-output '.expires')"
  user_devices_cur="$(echo $user_json | jq --raw-output '.devices.current')"
  user_devices_max="$(echo $user_json | jq --raw-output '.devices.max')"

  # display user data
  echo "Username: ${param_username}"

  if [ -n "${user_trial}" ]; then
    echo -n "Account type: "
    case "${user_trial}" in
      "true")  echo "trial"   ;;
      "false") echo "paid"    ;;
      *)       echo "unknown" ;;
    esac
  fi

  if [ -n "${user_expires}" ]; then
    echo "Account expiration date: $(LC_ALL=C date -d "+${user_expires} secs")"
  fi

  if [ -n "${user_devices_max}" ] && [ -n "${user_devices_cur}" ]; then
    if [ "${user_devices_cur}" -gt "0" ]; then
      echo "You are currently using service on ${user_devices_cur} out of ${user_devices_max} devices"
    else
      echo "You can use service on ${user_devices_max} devices at the same time"
    fi
  fi
fi
