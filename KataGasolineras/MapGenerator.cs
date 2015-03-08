using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataGasolineras
{
    public class MapGenerator
    {
        private int numberOfPetrolStations = 10;
        private Map map;

        public MapGenerator(Map map)
        {
            this.map = map;
        }

        public MapElements GenerateMapElements()
        {
            return new MapElements(GeneratePetrolStations(), GenerateJourney());
        }
         

        private PetrolStationList GeneratePetrolStations()
        {
            PetrolStationList petrolStationList = new PetrolStationList();

            while (petrolStationList.Count() < numberOfPetrolStations)
	        {
	            PetrolStation petrolStation = GeneratePetrolStation();
                if (petrolStationList.ValidateDistance(petrolStation))
                {
                    petrolStationList.Add(petrolStation);
                }               
	        }

            return petrolStationList;
        }

        private Journey GenerateJourney()
        {
            Position initialPosition = Position.GeneratePosition(map.MapDimension);
            Position finalPosition = Position.GeneratePosition(map.MapDimension);

            Journey journey = new Journey(initialPosition, finalPosition);

            while (!journey.IsAtMinimumDistanceAllowed())
            {
                GenerateJourney();
            }

            return journey;
        }
       
        private PetrolStation GeneratePetrolStation()
        {
            Position position = Position.GeneratePosition(map.MapDimension);
            PetrolStation petrolStation = new PetrolStation(position);

            return petrolStation;
        }
    }
}
