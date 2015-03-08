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
        private MapElements elements;

        public MapElements Elements
        {
           get { return elements; }
        }

        public MapDimension MapDimension
        {
            get { return mapDimension; }
        }
   

        public Map()
        {
            this.mapDimension = new MapDimension(1000, 1000);
            GenerateElements();           
        }

        private void GenerateElements()
        {
            elements = new MapGenerator(this).GenerateMapElements();
        }
    }
}
