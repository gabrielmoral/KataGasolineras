using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataGasolineras
{
    public class MapDimension
    {
        private int horizontalDimension;
        private int verticalDimension;

        public int HorizontalDimension
        {
            get { return horizontalDimension; }         
        }

        public int VerticalDimension
        {
            get { return verticalDimension; }         
        }

        public MapDimension(int horizontalDimension, int verticalDimension)
        {
            this.horizontalDimension = horizontalDimension;
            this.verticalDimension = verticalDimension;
        }
    }
}
