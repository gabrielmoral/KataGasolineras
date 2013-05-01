$(document).ready(function () {

    var width = 1000;
    var height = 1000;
    var $grid = $("#grid");

    $grid.attr("width", width);
    $grid.attr("height", height);

    createMap(width, height);   
    createPetrolStationList();            

    $("#btnEmptyPetrol").click(function () {
        carFuelEmpty();
    });

     $("#btnFindPetrolStation").click(function () {
        findNearbyPetrolStation();
    });
});

function Position(x, y) {
    this.X = x;
    this.Y = y;
}

function createPetrolStation(position, radius) {
    createCircle(position, "green", radius);
}

function createCircle(position, colour, radius) {
    $("#grid").drawArc({
        fillStyle: colour,
        x: position.X, y: position.Y,
        radius: radius
    });
}

function createJourney(journey) {
    createLine(journey.InitialPosition, journey.FinalPosition);
}

function createLine(initialPosition, finalPosition) {
    $("#grid").drawLine({
        strokeStyle: "#000000",
        strokeWidth: 1,
        x1: initialPosition.X, y1: initialPosition.Y,
        x2: finalPosition.X, y2: finalPosition.Y
    });
}

function createMap(width, height){
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

function createPetrolStationList(){

    var url = 'KataGasolineras.aspx/GetMap';

    $.ajax({
        type: "POST",
        url: url,
        contentType: "application/json; charset=utf-8",               
        success: function (data) {
            var map = data.d;

            createJourney(map.Journey);

            $.each(map.PetrolStationList.PetrolStations, function (i, item) {
                createPetrolStation(item.Position, 4);
            }); 
        }
    });
}

function carFuelEmpty() {
    var url = "KataGasolineras.aspx/CarFuelEmpty";

    $.ajax({
        type: "POST",
        url: url,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var positionCarFuelEmpty = data.d;                    
            createCircle(positionCarFuelEmpty, "red", 4);
        }
    });
}

function findNearbyPetrolStation() {
    var url = "KataGasolineras.aspx/FindNearbyPetrolStation"; 
    $.ajax({
        type: "POST",
        url: url,              
        contentType: "application/json; charset=utf-8",               
        success: function (data) {
            var position = data.d;
            createPetrolStation(position, 8);
        }
    });
}