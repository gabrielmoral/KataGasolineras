function Painter() {};

var painter = new Painter();

function Position(x, y) {
    this.X = x;
    this.Y = y;
}

Painter.prototype.createPetrolStation = function(position, radius) {
	createCircle(position, "green", radius);
}	

Painter.prototype.createPositionWithouthFuel = function(position) {
	createCircle(position, "red", 4);
}

Painter.prototype.createJourney = function(journey) {
	createLine(journey.InitialPosition, journey.FinalPosition);
}

Painter.prototype.createMap = function (width, height){
    for (var x = 0; x <= width; x = x + 5) {
        var initialPosition = new Position(x, 0);
        var finalPosition = new Position(x, width);
        createLine(initialPosition, finalPosition);
    }

    for (var y = 0; y <= height; y = y + 5) {
        var initialPosition = new Position(0, y);
        var finalPosition = new Position(height, y);
        createLine(initialPosition, finalPosition);
    }
}

function createLine(initialPosition, finalPosition) {
	    $("#grid").drawLine({
	        strokeStyle: "#000000",
	        strokeWidth: 1,
	        x1: initialPosition.X, y1: initialPosition.Y,
	        x2: finalPosition.X, y2: finalPosition.Y
	    });
	}	

function createCircle(position, colour, radius) {
    $("#grid").drawArc({
        fillStyle: colour,
        x: position.X, y: position.Y,
        radius: radius
    });
}
