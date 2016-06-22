//Dependencies

var express = require('express');
var fs = require('fs');
var app = express();

//Json DATA

var lavatorioLevel = null;

var catacombsLevel = null;

var aguasLevel = null;

var vista360 = null;


//Puzzle :  "Dispara el inicio del puzzle"
//Trigger : "Dispira el inicio de otro evento como abrir una puerta"


//Primer Nivel lavatorio

app.get('/lavatorioLevel' , function(req,res) {
	console.log("Level 1 data called");
	res.send(JSON.stringify(lavatorioLevel));
});

app.put('/lavatorioLevel/primerPuzzle/:door/:puzzle' , function(req, res) {
	var newDoor = req.params.door;
	var newPuzzle = req.params.puzzle;
	lavatorioLevel = [
		{"trigger" : newDoor , "puzzle" : newPuzzle},
		{"trigger" : "false", "puzzle" : "false"}
		];
	console.log("Lavatorio puzzle #1 Updated");
	res.end("Lavatorio puzzle #1 Updated");
});

app.put('/lavatorioLevel/segundoPuzzle/:door/:puzzle' , function(req,res) {
	var newDoor = req.params.door;
	var newPuzzle = req.params.puzzle;
	lavatorioLevel = [
		{"trigger" : "false", "puzzle" : "false"},
		{"trigger" : newDoor, "puzzle" : newPuzzle}
		];
	console.log("Lavatorio puzzle #2 Updated");
	res.end("Lavatorio puzzle #2 Updated");
});

//Segundo Nivel AguasSubterraneas

app.get('/aguasLevel' , function(req,res) {
	console.log("Level 2 data called");
	res.send(JSON.stringify(aguasLevel));
});

app.put('/aguasLevel/primerPuzzle/:trigger/:puzzle' , function(req,res){
	var newTrigger = req.params.trigger;
	var newPuzzle = req.params.puzzle;
	aguasLevel = [ 
		{"trigger" : newTrigger , "puzzle" : newPuzzle},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"}
	];
	console.log("Aguas puzzle #1 Updated");
	res.end("Aguas puzzle #1 Updated");
});
app.put('/aguasLevel/segundoPuzzle/:trigger/:puzzle' , function(req,res){
	var newTrigger = req.params.trigger;
	var newPuzzle = req.params.puzzle;
	aguasLevel = [ 
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : newTrigger , "puzzle" : newPuzzle},
		{"trigger" : "false" , "puzzle" : "false"}
	];
	console.log("Aguas puzzle #2 Updated");
	res.end("Aguas puzzle #2 Updated");
});

app.put('/aguasLevel/tercerPuzzle/:trigger/:puzzle' , function(req,res){
	var newTrigger = req.params.trigger;
	var newPuzzle = req.params.puzzle;
	aguasLevel = [ 
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : newTrigger , "puzzle" : newPuzzle}
	];
	console.log("Aguas puzzle #3 Updated");
	res.end("Aguas puzzle #3 Updated");
});


//Tercer Nivel Catacombs

app.get('/catacombsLevel' , function(req,res) {
	console.log("Level 3 data called");
	res.send(JSON.stringify(catacombsLevel));
});

app.put('/catacombsLevel/primerPuzzle/:trigger/:puzzle' , function(req,res) {
	var newTrigger = req.params.trigger;
	var newPuzzle = req.params.puzzle;
	catacombsLevel = [
		{"trigger" : newTrigger , "puzzle" : newPuzzle},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"}
	];
	console.log("Catacombs puzzle #1 Updated");
	res.end("Catacombs puzzle #1 Updated");
});

app.put('/catacombsLevel/segundoPuzzle/:trigger/:puzzle' , function(req,res) {
	var newTrigger = req.params.trigger;
	var newPuzzle = req.params.puzzle;
	catacombsLevel = [
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : newTrigger , "puzzle" : newPuzzle},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"}
	];
	console.log("Catacombs puzzle #2 Updated");
	res.end("Catacombs puzzle #2 Updated");
});


app.put('/catacombsLevel/tercerPuzzle/:trigger/:puzzle' , function(req,res) {
	var newTrigger = req.params.trigger;
	var newPuzzle = req.params.puzzle;
	catacombsLevel = [
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : newTrigger , "puzzle" : newPuzzle},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"}
	];
	console.log("Catacombs puzzle #3 Updated");
	res.end("Catacombs puzzle #3 Updated");
});


app.put('/catacombsLevel/cuartoPuzzle/:trigger/:puzzle' , function(req,res) {
	var newTrigger = req.params.trigger;
	var newPuzzle = req.params.puzzle;
	catacombsLevel = [
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : newTrigger , "puzzle" : newPuzzle},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"}
	];
	console.log("Catacombs puzzle #4 Updated");
	res.end("Catacombs puzzle #4 Updated");
});


app.put('/catacombsLevel/quintoPuzzle/:trigger/:puzzle' , function(req,res) {
	var newTrigger = req.params.trigger;
	var newPuzzle = req.params.puzzle;
	catacombsLevel = [
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : newTrigger , "puzzle" : newPuzzle},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"}
	];
	console.log("Catacombs puzzle #5 Updated");
	res.end("Catacombs puzzle #5 Updated");
});


app.put('/catacombsLevel/sextoPuzzle/:trigger/:puzzle' , function(req,res) {
	var newTrigger = req.params.trigger;
	var newPuzzle = req.params.puzzle;
	catacombsLevel = [
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : newTrigger , "puzzle" : newPuzzle},
		{"trigger" : "false" , "puzzle" : "false"}
	];
	console.log("Catacombs puzzle #6 Updated");
	res.end("Catacombs puzzle #6 Updated");
});

app.put('/catacombsLevel/septimoPuzzle/:trigger/:puzzle' , function(req,res) {
	var newTrigger = req.params.trigger;
	var newPuzzle = req.params.puzzle;
	catacombsLevel = [
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : "false" , "puzzle" : "false"},
		{"trigger" : newTrigger , "puzzle" : newPuzzle}
	];
	console.log("Catacombs puzzle #7 Updated");
	res.end("Catacombs puzzle #7 Updated");
});

app.get('/vista360' , function(req,res) {
	console.log("Vista 360 data called");
	res.send(JSON.stringify(vista360));
})

app.put('/vista360/:scene' , function(req,res) {
	var newScene = req.params.scene;
	vista360 = {"scene" : newScene};
	console.log("Vista 360 data Updated");
	res.end("Vista 360 data Updated");
});

//Iniciar el servidor

var server = app.listen(8081,function(){
	var port = server.address().port;
	console.log("Server listening at port : " + port);
})