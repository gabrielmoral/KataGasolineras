using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace KataGasolineras.Web
{
    public partial class KataGasolineras : System.Web.UI.Page
    {
        private static Map map;
        private static Position positionWithoutFuel;

        [WebMethod]
        public static Map GetMap()
        {
            map = new Map();
            return map;        
        }

        [WebMethod]
        public static Position CarFuelEmpty()
        {
            positionWithoutFuel = map.Journey.CarFuelEmpty();
            return positionWithoutFuel;
        }

        [WebMethod]
        public static Position FindNearbyPetrolStation()
        {
            Position nearbyPetrolStationPosition = map.PetrolStationList.FindNearbyPetrolStation(positionWithoutFuel).Position;
            return nearbyPetrolStationPosition;
        }
    }
}