using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataGasolineras
{
    public class PetrolStationList
    {
        private IList<PetrolStation> petrolStationList;

        public PetrolStationList()
        {
            petrolStationList = new List<PetrolStation>();
        }        

        public bool ValidateDistance(PetrolStation petrolStation)
        {
            return IsPetrolStationDistanceValidWithOthers(petrolStation);
        }

        public void Add(PetrolStation petrolStation)
        {
            petrolStationList.Add(petrolStation);
        }

        private bool IsPetrolStationDistanceValidWithOthers(PetrolStation petrolStation)
        {
            bool isValidDistance = true;

            //If one petrolStation is found distance isn't valid 
            PetrolStation foundPetrolStation = (from e in petrolStationList
                                           where !e.IsValidDistance(petrolStation)
                                           select e).FirstOrDefault();

            if (foundPetrolStation != null)
            {
                isValidDistance = false;
            }

            return isValidDistance;
        }

        public int Count()
        {
            return petrolStationList.Count;
        }

        public IEnumerator<PetrolStation> GetEnumerator()
        {
            return petrolStationList.GetEnumerator();
        }

        public PetrolStation FindNearbyPetrolStation(Position position)
        {
            return FindPetrolStationWithMinDistance(position);
        }

        private PetrolStation FindPetrolStationWithMinDistance(Position position)
        {
            return petrolStationList.OrderBy(p => p.Position.CalculateDistance(position)).FirstOrDefault();            
        }       
    }
}
