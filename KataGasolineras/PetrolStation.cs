using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataGasolineras
{
    public class PetrolStation
    {
        private const int MinimumDistance = 5;
        private Position position;

        public Position Position
        {
            get { return position; }            
        }      

        public PetrolStation(Position position)
        {
            this.position = position;
        }

        public bool IsValidDistance(PetrolStation petrolStation)
        {
            return position.IsValidDistance(petrolStation.position, MinimumDistance);
        }
    }
}
