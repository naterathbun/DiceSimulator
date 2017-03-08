using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceSimulator
{
    public class Dice
    {
        private int Sides;
        private Random RandomNumber = new Random();

        public Dice(int sides)
        {
            if (sides < 1)
            {
                sides = 1;
            }

            this.Sides = sides;
        }

        public int Roll()
        {
            return RandomNumber.Next(1, (this.Sides + 1));
        }
    }
}
