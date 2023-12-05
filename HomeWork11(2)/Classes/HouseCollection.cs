using HouseBuildingLibruary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11.Classes
{
    public class HouseCollection
    {
        public House this[int number]
        {
            get
            {
                foreach (House h in houses)
                {
                    if (h.Number == number)
                    {
                        return h;
                    }
                }
                return null;
            }
        }

        House[] houses = new House[10];

        public void AddHouse(House house)
        {
            bool flag = false;
            for (int i = 0; i < 10; i++)
            {
                if (houses[i] == null)
                {
                    houses[i] = house;
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Места в коллекции закончились");
            }
        }
    }
}
