using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataGasolineras.Test
{  
    [TestClass]
    public class TestPetrolStation
    {
        [TestMethod]
        public void PetrolStationMeetsMinimumDistance()
        {
            Position position1 = new Position(110, 100);
            Position position2 = new Position(115, 95);           

            PetrolStation petrolStation1 = new PetrolStation(position1);
            PetrolStation petrolStation2 = new PetrolStation(position2);

            bool isAtMinimumDistance = petrolStation1.IsAtMinimumDistance(petrolStation2);

            Assert.IsTrue(isAtMinimumDistance);
        }

        [TestMethod]
        public void PetrolStationNotMeetsMinimumDistance()
        {
            Position position1 = new Position(1, 1);
            Position position2 = new Position(2, 2);

            PetrolStation petrolStation1 = new PetrolStation(position1);
            PetrolStation petrolStation2 = new PetrolStation(position2);

            bool isAtMinimumDistance = petrolStation1.IsAtMinimumDistance(petrolStation2);

            Assert.IsFalse(isAtMinimumDistance);
        }
    }
}
