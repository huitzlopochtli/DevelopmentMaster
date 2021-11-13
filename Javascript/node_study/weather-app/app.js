require('dotenv').config();

const config  = require('./config');
const env = process.env; 

const request = require('request');
const API_key = config.OPEN_WEATHER_APIKEY || env.OPEN_WEATHER_APIKEY;
const LAT = '35.6875411';
const LON = '139.7013494';

const url = `https://api.openweathermap.org/data/2.5/onecall?lat=${LAT}&lon=${LON}&appid=${API_key}&units=metric`;

request({
	url: url,
	json: true
}, (error, response) => {
	if (!error) {
		const weatherDesc = response.body.current.weather[0].description;
		const temperature = response.body.current.temp;
		console.log(`It is currently ${weatherDesc} with temperature of ${temperature} degree celcius`);
	} else {
		console.log('Unable to connect to the weather service');
	}
});
