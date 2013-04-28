using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataGasolineras
{
    public class ElementMapGenerator
    {
        private int numberOfPetrolStations = 10;
        private Map map;

        public ElementMapGenerator(Map map)
        {
            this.map = map;
        }

        public PetrolStationList GeneratePetrolStations()
        {
            PetrolStationList petrolStationList = new PetrolStationList();

            while (petrolStationList.Count() < numberOfPetrolStations)
	        {
	            PetrolStation petrolStation = GeneratePetrolStation(map.MapDimension);
                petrolStationList.AddPetrolStationIfIsValidDistance(petrolStation);
	        }

            return petrolStationList;
        }

        public Journey GenerateJourney()
        {
            Position initialPosition = Position.GeneratePosition(map.MapDimension);
            Position finalPosition = Position.GeneratePosition(map.MapDimension);

            Journey journey = new Journey(initialPosition, finalPosition);

            if (!journey.IsValidDistance())
            {
                journey =  GenerateJourney();
            }

            return journey;
        }
       
        public PetrolStation GeneratePetrolStation(MapDimension mapDimension)
        {
            Position position = Position.GeneratePosition(mapDimension);
            PetrolStation petrolStation = new PetrolStation(position);

            return petrolStation;
        }
    }
}
