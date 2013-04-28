using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataGasolineras
{
    public class Journey
    {
        MiniumDistance miniumDistance;
        private Position initialPosition;
        private Position finalPosition;
        private PositonList positionList;

        public PositonList PositionList
        {
            get { return positionList; }            
        }
        
        public Journey(Position initialPosition, Position finalPosition)
        {
            this.miniumDistance = new MiniumDistance(200);
            this.initialPosition = initialPosition;
            this.finalPosition = finalPosition;
            GeneratePositionList();
        }

        public bool IsValidDistance()
        {
            return this.initialPosition.IsValidDistance(this.finalPosition, this.miniumDistance);
        }

        private void GeneratePositionList()
        {
            positionList = new PositonList();

            double distance = this.initialPosition.CalculateDistance(this.finalPosition);

            Position summatoryPosition = this.initialPosition.GetSummatoryPosition(this.finalPosition);

            double initialPositionX = this.initialPosition.X;
            double initialPositionY = this.initialPosition.Y;

            for (int i = 0; i <= distance; i++)
            {
                double newPositionX = initialPositionX + summatoryPosition.X;
                double newPositionY = initialPositionX + summatoryPosition.Y;

                positionList.Add(new Position(newPositionX, newPositionY));

                initialPositionX = newPositionX;
                initialPositionY = newPositionY;
            }
        }

        public Position EmptyPetrol()
        {
            return this.positionList.GetRandomPosition();
        }
    }
}
