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
        public void FindNearbyPetrolStationInJourney()
        {
            Map map = new Map();

            Position positionWithOutGas = new Position(2, 3);
            PetrolStation nearbyPetrolStation = new PetrolStation(new Position(3, 3));

            map.Journey.JourneyPositionList.Add(new Position(0, 1));
            map.Journey.JourneyPositionList.Add(new Position(1, 2));
            map.Journey.JourneyPositionList.Add(positionWithOutGas);
            map.Journey.JourneyPositionList.Add(new Position(3, 4));

            map.PetrolStationList.Add(nearbyPetrolStation);

            PetrolStation foundPetrolStation = map.PetrolStationList.FindNearbyPetrolStation(positionWithOutGas);

            Assert.AreEqual(nearbyPetrolStation, foundPetrolStation);
        }
    }
}
