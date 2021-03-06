﻿using System;
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
            bool result = journey.IsAtMinimumDistanceAllowed();
        
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void JourneyNotMeetsMinimumDistance()
        {
            Position initialPosition = new Position(1, 200);
            Position finalPosition = new Position(100, 50);
         
            Journey journey = new Journey(initialPosition, finalPosition);
            bool result = journey.IsAtMinimumDistanceAllowed();

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsValidPositionWhenCarFuelEmpty()
        {
            Map map = new Map();

            Position position = map.Elements.Journey.CarFuelEmpty();

            bool result = map.Elements.Journey.JourneyPositionList.Contains(position);

            Assert.AreEqual(true, result);
        }
    }
}
