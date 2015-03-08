using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataGasolineras
{
    public class MapElements
    {
        private PetrolStationList petrolStationList;

        private Journey journey;

        public PetrolStationList PetrolStationList
        {
            get { return petrolStationList; }          
        }

        public Journey Journey
        {
            get { return journey; }
            set { journey = value; }
        }

        public MapElements(PetrolStationList petrolStationList, Journey journey)
        {        
            this.petrolStationList = petrolStationList;
            this.journey = journey;
        }
    }
}
