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
        [TestMethod]
        public void JourneyMeetsMinimumDistance()
        {
            Position initialPosition = new Position(1, 200);
            Position finalPosition = new Position(400, 400);         

            Journey journey = new Journey(initialPosition, finalPosition);
            bool result = journey.IsValidDistance();
        
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void JourneyNotMeetsMinimumDistance()
        {
            Position initialPosition = new Position(1, 200);
            Position finalPosition = new Position(100, 50);
         
            Journey journey = new Journey(initialPosition, finalPosition);
            bool result = journey.IsValidDistance();

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsValidPositionWhenCarFuelEmpty()
        {
            Map map = new Map();

            Position position = map.Journey.CarFuelEmpty();

            bool result = map.Journey.JourneyPositionList.Contains(position);

            Assert.AreEqual(true, result);
        }


        [TestMethod]
        public void FirstJourneyPositionIsEqualsInitialPosition()
        {
            Map map = new Map();

            Position firstPosition = map.Journey.JourneyPositionList.GetPosition(1);

            Position initialPosition = map.Journey.InitialPosition;

            //Assert.AreEqual(initialPosition.X, firstPosition.X);
            //Assert.AreEqual(initialPosition.Y, firstPosition.Y);
        }
    }
}
