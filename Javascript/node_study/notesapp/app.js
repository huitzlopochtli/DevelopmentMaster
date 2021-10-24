const fs = require('fs');

// It will create a new file 
// put the text to the file
fs.writeFileSync('notes.txt', 'this file was created by node js\n');
// it will append to the file
fs.appendFileSync('notes.txt', 'this is appened!');