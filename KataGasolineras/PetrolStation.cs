using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataGasolineras
{
    public class PetrolStation
    {
        MiniumDistance miniumDistance;
        Position position;

        public Position Position
        {
            get { return position; }            
        }      

        public PetrolStation(Position position)
        {
            miniumDistance = new MiniumDistance(5);
            this.position = position;
        }

        public bool IsValidDistance(PetrolStation petrolStation)
        {
            return this.position.IsValidDistance(petrolStation.position, miniumDistance);
        }
    }
}
