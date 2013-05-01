using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataGasolineras
{
    public class JourneyPositonList
    {
        private IList<Position> journeyPositionList;

        public JourneyPositonList()
        {
            journeyPositionList = new List<Position>();
        }

        public void Add(Position position)
        {
            this.journeyPositionList.Add(position);
        }

        public Position GetRandomPosition()
        {
            Random random = new Random(DateTime.Now.Millisecond);

            int index = random.Next(0, journeyPositionList.Count);

            return journeyPositionList[index];
        }

        public bool Contains(Position position)
        {
            bool found = false;
            var foundPosition = (from e in journeyPositionList
                                 where e.X == position.X && e.Y == position.Y
                                 select e).FirstOrDefault();

            if (foundPosition != null)
            {
                found =  true;
            }

            return found;
        }

        public Position GetPosition(int index)
        {
            return journeyPositionList[index];
        }
    }
}
