#!/bin/bash

index=1

cat nordvpn.pass |
while read emailpassword seperator expire date time;
do
    IFS=':' read -r -a array <<< "$emailpassword"
    email="${array[0]}"
    password="${array[1]}"

    printf $index

    index=$((index+1))

    ./nordvpn.sh -u $email -p $password
done
