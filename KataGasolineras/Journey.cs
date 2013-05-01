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
        private JourneyPositonList journeyPositionList;

        public Position InitialPosition
        {
            get { return initialPosition; }      
        }        

        public Position FinalPosition
        {
            get { return finalPosition; }            
        }        

        public JourneyPositonList JourneyPositionList
        {
            get { return journeyPositionList; }            
        }
        
        public Journey(Position initialPosition, Position finalPosition)
        {   
            this.initialPosition = initialPosition;
            this.finalPosition = finalPosition;
            GenerateJourneyPositions();
        }

        public bool IsValidDistance()
        {
            return initialPosition.IsValidDistance(finalPosition, MinimumDistance);
        }

        public Position CarFuelEmpty()
        {
            return journeyPositionList.GetRandomPosition();
        }

        private void GenerateJourneyPositions()
        {
            journeyPositionList = new JourneyPositonList();

            double distance = CalculateJourneyDistance();
            
            Position summatoryPosition = GenerateSummatoryPosition();

            double initialPositionX = initialPosition.X;
            double initialPositionY = initialPosition.Y;

            for (int i = 0; i <= distance; i++)
            {
                double newPositionX = initialPositionX + summatoryPosition.X;
                double newPositionY = initialPositionY + summatoryPosition.Y;

                journeyPositionList.Add(new Position(newPositionX, newPositionY));

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
