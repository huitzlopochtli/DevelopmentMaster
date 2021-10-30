// const { name, add } = require('./utils.js');
// const { getNotes } = require('./notes');

// const validator = require('validator');

import validator from 'validator';
import chalk from 'chalk';


console.log(validator.isEmail('test'));
console.log(validator.isURL('peeyalk.com'));

console.log(chalk.red.inverse.bold('Error'));
