using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ohfortuna
{
    internal class Dice
    {
        public int Value { get; set; }
        private readonly Random random;

        //varje tärning har en egen slump-generator
        public Dice()
        {
            random = new Random();
        }

        //Tilldela tärningen ett nytt värde
        public void RollDice()
        {
            Value = random.Next(1, 7);
        }
    }
}
