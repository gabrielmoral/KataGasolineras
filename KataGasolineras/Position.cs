using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataGasolineras
{
    public class Position
    {      
        private double x;
        private double y;

        public double X
        {
            get { return x; }           
        }

        public double Y
        {
            get { return y; }          
        }

        public Position(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Position GeneratePosition(MapDimension mapDimension)
        {
            return RandomPositionMap.GeneratePosition(mapDimension);
        }

        public bool IsValidDistance(Position position, int MinimumDistance)
        {
            return CalculateDistance(position) >= MinimumDistance;
        }

        public double CalculateDistance(Position position)
        {   
            return Math.Sqrt(Math.Pow(this.x - position.x, 2) + Math.Pow(this.y - position.y, 2));
        }

        public Position GetSummatoryPosition(Position position)
        {
            double distance = CalculateDistance(position);

            Position vectorPosition = GetVectorPosition(position);

            Position summatoryPosition = new Position(vectorPosition.x / distance, vectorPosition.y / distance);

            return summatoryPosition;
        }

        private Position GetVectorPosition(Position position)
        {
            return new Position(position.x - this.x, position.y - this.y);
        }
    }
}
