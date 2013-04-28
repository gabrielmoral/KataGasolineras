using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataGasolineras
{
    public class PositonList
    {
        private IList<Position> positionList;

        public PositonList()
        {
            positionList = new List<Position>();
        }

        public void Add(Position position)
        {
            this.positionList.Add(position);
        }

        public Position GetRandomPosition()
        {
            Random random = new Random(DateTime.Now.Millisecond);

            int index = random.Next(0, positionList.Count);

            return positionList[index];
        }
    }
}
