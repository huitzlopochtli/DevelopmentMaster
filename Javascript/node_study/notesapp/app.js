const yargs = require('yargs');
const notesRepository = require('./notes');



// Create Add Command
yargs.command({
	command: 'add',
	describe: 'Add a new note',
	builder: {
		title: {
			describe: 'Note title',
			demandOption: true,
			type: 'string'
		},
		body:{
			describe: 'Note Body',
			demandOption:true,
			type: 'string'
		}
	},
	handler: (argv) => {
		notesRepository.addNote(argv.title, argv.body);
	}
});

yargs.command({
	command: 'remove',
	describe: 'Remove a note',
	builder: {
		title: {
			describe: 'Note title',
			demandOption: true,
			type: 'string'
		}
	},
	handler: (argv) => {
		notesRepository.removeNode(argv.title);
	}
});

yargs.command({
	command: 'list',
	describe: 'List of notes',
	handler: () => {
		notesRepository.listNodes();
	}
});

yargs.command({
	command: 'read',
	describe: 'Read a note',
	builder: {
		title: {
			describe: 'Note title',
			demandOption: true,
			type: 'string'
		}
	},
	handler: (argv) => {
		notesRepository.readNode(argv.title);
	}
});

yargs.parse();