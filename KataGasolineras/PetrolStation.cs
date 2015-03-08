using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataGasolineras
{
    public class PetrolStation
    {
        private const int MINIMUM_DSTANCE_BETWEEN_PETROL_STATIONS = 5;
        private Position position;

        public Position Position
        {
            get { return position; }            
        }      

        public PetrolStation(Position position)
        {
            this.position = position;
        }

        public bool IsAtMinimumDistance(PetrolStation petrolStation)
        {
            return position.IsAtMinimumDistance(petrolStation.position, MINIMUM_DSTANCE_BETWEEN_PETROL_STATIONS);
        }
    }
}
