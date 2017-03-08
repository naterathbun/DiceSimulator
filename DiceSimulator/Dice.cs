using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceSimulator
{
    public class Dice
    {
        public int Sides { get; set; }
        public Random RandomNumber { get; set; } = new Random();

        public Dice(int sides)
        {
            this.Sides = sides;
        }

        public int Roll()
        {
            return RandomNumber.Next(1, (this.Sides + 1));
        }
    }
}
