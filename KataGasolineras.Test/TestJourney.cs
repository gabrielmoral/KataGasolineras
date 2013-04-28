using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataGasolineras.Test
{
    [TestClass]
    public class TestJourney
    {
        MiniumDistance miniumDistance;

        [TestInitialize]
        public void SetUp()
        {
            miniumDistance = new MiniumDistance(200);
        }


        [TestMethod]
        public void JourneyMeetsMiniumDistance()
        {
            Position initialPosition = new Position(1, 200);
            Position finalPosition = new Position(400, 400);         

            Journey journey = new Journey(initialPosition, finalPosition);
            bool result = journey.IsValidDistance();
        
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void JourneyNotMeetsMiniumDistance()
        {
            Position initialPosition = new Position(1, 200);
            Position finalPosition = new Position(100, 50);
         
            Journey journey = new Journey(initialPosition, finalPosition);
            bool result = journey.IsValidDistance();

            Assert.AreEqual(false, result);
        }        
    }
}
