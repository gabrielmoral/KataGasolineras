using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataGasolineras
{
    public class RandomPositionMap
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        public static Position GeneratePosition(MapDimension mapDimension)
        {
            int horizontalPosition;
            int verticalPosition;

            lock (syncLock)
            {
                horizontalPosition = random.Next(0, mapDimension.HorizontalDimension);
                verticalPosition = random.Next(0, mapDimension.VerticalDimension);
            }

            return new Position(horizontalPosition, verticalPosition);
        }
       
    }
}
