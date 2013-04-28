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
        ElementMapGenerator elementMapGenerator;

        [TestInitialize]
        public void SetUp()
        {
            map = new Map();
            elementMapGenerator = new ElementMapGenerator(map);
        }

        [TestMethod]
        public void GenerateValidPetrolStations()
        {           
            PetrolStationList petrolStationListGenerated = elementMapGenerator.GeneratePetrolStations();

            using (var petrolStationList = petrolStationListGenerated.GetEnumerator())
            {   
                var bufferPetrolStation = new List<PetrolStation>();

                while (petrolStationList.MoveNext())
                {
                    foreach (PetrolStation item in bufferPetrolStation)
                    {
                        Assert.AreEqual(true, item.IsValidDistance(petrolStationList.Current));       
                    }
                    bufferPetrolStation.Add(petrolStationList.Current);
                }
            } 
        }
        
        [TestMethod]
        public void GenerateValidJourney()
        {          
            Journey journey = elementMapGenerator.GenerateJourney();

            Assert.AreEqual(true, journey.IsValidDistance());
        }
    }
}
