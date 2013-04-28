using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataGasolineras
{
    public class Map
    {        
        private MapDimension mapDimension;
        private PetrolStationList petrolStationList;
        private Journey journey;

        public MapDimension MapDimension
        {
            get { return mapDimension; }
        }

        public Journey Journey
        {
            get { return journey; }          
        }

        public PetrolStationList PetrolStationList
        {
            get { return petrolStationList; }            
        }

        public Map()
        {
            this.mapDimension = new MapDimension(300, 300);
            GenerateElements();           
        }

        private void GenerateElements()
        {
            ElementMapGenerator elementMapGenerator = new ElementMapGenerator(this);
            this.petrolStationList = elementMapGenerator.GeneratePetrolStations();
            this.journey = elementMapGenerator.GenerateJourney();
        }
    }
}
