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
        public void PetrolStationMeetsMiniumDistance()
        {
            Position position1 = new Position(110, 100);
            Position position2 = new Position(115, 95);           

            PetrolStation petrolStation1 = new PetrolStation(position1);
            PetrolStation petrolStation2 = new PetrolStation(position2);

            bool result = petrolStation1.IsValidDistance(petrolStation2);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void PetrolStationNotMeetsMiniumDistance()
        {
            Position position1 = new Position(1, 1);
            Position position2 = new Position(2, 2);

            PetrolStation petrolStation1 = new PetrolStation(position1);
            PetrolStation petrolStation2 = new PetrolStation(position2);

            bool result = petrolStation1.IsValidDistance(petrolStation2);

            Assert.AreEqual(false, result);
        }
    }
}
