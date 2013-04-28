using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataGasolineras.Test
{
    [TestClass]
    public class TestPetrolStationList
    {
        [TestMethod]
        public void FindNearbyPetrolStationInJourneyWithManualPositions()
        {
            Map map = new Map();

            Position positionWithOutGas = new Position(2, 3);

            map.Journey.PositionList.Add(new Position(0, 1));
            map.Journey.PositionList.Add(new Position(1, 2));
            map.Journey.PositionList.Add(positionWithOutGas);
            map.Journey.PositionList.Add(new Position(3, 4));
            map.Journey.PositionList.Add(new Position(4, 5));
            map.Journey.PositionList.Add(new Position(5, 6));
            map.Journey.PositionList.Add(new Position(6, 7));

            PetrolStation foundPetrolStation = null;

            PetrolStation petrolStation = map.PetrolStationList.FindNearbyPetrolStation(positionWithOutGas);

            double auxDistance = 2000;

            foreach (PetrolStation petrolStationAdded in map.PetrolStationList)
            {
                double distance = petrolStationAdded.Position.CalculateDistance(positionWithOutGas);

                if (distance < auxDistance)
                {
                    auxDistance = distance;
                    foundPetrolStation = petrolStationAdded;
                }                
            }

            Assert.AreEqual(foundPetrolStation, petrolStation);
        }

        [TestMethod]
        public void FindNearbyPetrolStationInJourneyWithGeneratedPositions()
        {
            Map map = new Map();

            Position position = map.Journey.EmptyPetrol();

            PetrolStation foundPetrolStation = null;

            PetrolStation petrolStation = map.PetrolStationList.FindNearbyPetrolStation(position);

            double auxDistance = 2000;

            foreach (PetrolStation petrolStationAdded in map.PetrolStationList)
            {
                double distance = petrolStationAdded.Position.CalculateDistance(position);

                if (distance < auxDistance)
                {
                    auxDistance = distance;
                    foundPetrolStation = petrolStationAdded;
                }
            }

            Assert.AreEqual(foundPetrolStation, petrolStation);
        }
    }
}
