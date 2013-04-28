using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataGasolineras
{
    public class Journey
    {
        private const int MinimumDistance = 200;
        private Position initialPosition;
        private Position finalPosition;
        private PositonList positionList;

        public PositonList PositionList
        {
            get { return positionList; }            
        }
        
        public Journey(Position initialPosition, Position finalPosition)
        {   
            this.initialPosition = initialPosition;
            this.finalPosition = finalPosition;
            GeneratePositionList();
        }

        public bool IsValidDistance()
        {
            return initialPosition.IsValidDistance(finalPosition, MinimumDistance);
        }

        public Position EmptyPetrol()
        {
            return positionList.GetRandomPosition();
        }

        private void GeneratePositionList()
        {
            positionList = new PositonList();

            double distance = CalculateJourneyDistance();
            
            Position summatoryPosition = GenerateSummatoryPosition();

            double initialPositionX = initialPosition.X;
            double initialPositionY = initialPosition.Y;

            for (int i = 0; i <= distance; i++)
            {
                double newPositionX = initialPositionX + summatoryPosition.X;
                double newPositionY = initialPositionX + summatoryPosition.Y;

                positionList.Add(new Position(newPositionX, newPositionY));

                initialPositionX = newPositionX;
                initialPositionY = newPositionY;
            }
        }

        private Position GenerateSummatoryPosition()
        {
            return initialPosition.GetSummatoryPosition(finalPosition);
        }

        private double CalculateJourneyDistance()
        {
            return initialPosition.CalculateDistance(finalPosition);
        }       
    }
}
