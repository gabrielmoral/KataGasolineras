$(document).ready(function () {

    var width = 1000;
    var height = 1000;
    var $grid = $("#grid");

    $grid.attr("width", width);
    $grid.attr("height", height);

    painter.createMap(width, height);   
    getPetrolStationList();            

    $("#btnEmptyPetrol").click(function () {
        carFuelEmpty();
    });

     $("#btnFindPetrolStation").click(function () {
        findNearbyPetrolStation();
    });
});

function getPetrolStationList(){
    var url = 'KataGasolineras.aspx/GetMap';

    $.ajax({
        type: "POST",
        url: url,
        contentType: "application/json; charset=utf-8",               
        success: function (data) {
            var map = data.d;

            painter.createJourney(map.Journey);

            $.each(map.PetrolStationList.PetrolStations, function (i, item) {
                painter.createPetrolStation(item.Position, 4);
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
            painter.createPositionWithouthFuel(positionCarFuelEmpty);
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
            painter.createPetrolStation(position, 8);
        }
    });
}