using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataGasolineras.Test
{
    [TestClass]
    public class TestElementMapGenerator
    {
        Map map;
        MapGenerator elementMapGenerator;

        [TestInitialize]
        public void SetUp()
        {
            map = new Map();
            elementMapGenerator = new MapGenerator(map);
        }

        [TestMethod]
        public void GenerateValidPetrolStations()
        {           
            PetrolStationList petrolStationListGenerated = elementMapGenerator.GenerateMapElements().PetrolStationList;

            using (var petrolStationList = petrolStationListGenerated.GetEnumerator())
            {   
                var bufferPetrolStation = new List<PetrolStation>();

                while (petrolStationList.MoveNext())
                {
                    foreach (PetrolStation item in bufferPetrolStation)
                    {
                        Assert.AreEqual(true, item.IsAtMinimumDistance(petrolStationList.Current));       
                    }
                    bufferPetrolStation.Add(petrolStationList.Current);
                }
            } 
        }
        
        [TestMethod]
        public void GenerateValidJourney()
        {          
            Journey journey = elementMapGenerator.GenerateMapElements().Journey;

            Assert.AreEqual(true, journey.IsAtMinimumDistanceAllowed());
        }
    }
}
