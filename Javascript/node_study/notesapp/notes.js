const fs = require('fs');
const chalk = require('chalk');
const errorStyle = chalk.bold.red.inverse;
const successStyle = chalk.bold.green.inverse;
const bgYellow = chalk.bgYellow.bold;
const bgRed = chalk.bgRed.bold;
const getNotes = () => 'My notes';

const noteJsonFile = process.cwd() + '/data/notes.json';

/**
 * 
 * @param {string} title 
 * @param {string} body 
 */
const addNote = (title, body) => {
	const notes = loadNotes();

	const duplicateNote = notes.find( (note) => note.title === title );

	if(duplicateNote === undefined){
		notes.push({
			title: title,
			body: body
		});
	
		saveNotes(notes);
		console.log(`New note added! Title: ${title} Body: ${body}`);
	} else {
		console.log(`Note aleady exist with Title: ${title}`);
	}


};

/**
 * 
 * @param {string} title 
 */
const removeNode = (title) => {
	const notes = loadNotes();

	const filteredNoted = notes.filter( (note) => {
		return note.title !== title;
	});

	if(filteredNoted.length === notes.length){
		console.log(errorStyle(`Note not found with Title: ${bgYellow(title)}`));
	} else {
		saveNotes(filteredNoted);
		console.log(successStyle(`Note removed with Title: ${bgRed(title)}`));
	}
};

/**
 * 
 */
const listNodes = () => {
	console.log(chalk.inverse('Your notes'));

	const notes = loadNotes();
	notes.forEach((note) => {
		console.log(note.title);
	});
};

/**
 * 
 * @param {string} title 
 */
const readNode = (title) => {
	const notes = loadNotes();
	const noteToRead = notes.find( (note)  => note.title === title);

	if(noteToRead){
		console.log(noteToRead.body);
	} else {
		console.log('Note not found!');
	}
};

/**
 * 
 * @returns {[{title, body}]} ListofNotes
 */
const loadNotes = () => {
	try {
		const dataBuffer = fs.readFileSync(noteJsonFile);
		const dataJson = dataBuffer.toString();
		return JSON.parse(dataJson);
	} catch (e) {
		console.log('notes.json file does not exit\nCreating file....');
		fs.mkdirSync(require('path').dirname(noteJsonFile));
		fs.writeFileSync(noteJsonFile, '');
		return [];
	}
};

/**
 * 
 * @param { array [{title, body}] } notes 
 */
const saveNotes = (notes) => {
	const dataJson = JSON.stringify(notes);
	fs.writeFileSync(noteJsonFile, dataJson);	
};


module.exports = { 
	getNotes: getNotes,
	addNote: addNote,
	removeNode: removeNode,
	listNodes: listNodes,
	readNode: readNode 
};


