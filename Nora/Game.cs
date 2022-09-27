using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ohfortuna
{
    internal class Game
    {
        //Tärningarna
        private readonly Dice dice1;
        private readonly Dice dice2;
        private readonly Dice dice3;

        //Skapa en spelmotor
        public Game()
        {
            this.dice1 = new Dice();
            this.dice2 = new Dice();
            this.dice3 = new Dice();
        }

        //Spela en runda
        public int PlayOneRound(int chosenNumber, int bet)
        {
            dice1.RollDice();
            Console.WriteLine("Dice one rolled: " + dice1.Value);
            dice2.RollDice();
            Console.WriteLine("Dice two rolled: " + dice2.Value);
            dice3.RollDice();
            Console.WriteLine("Dice three rolled: " + dice3.Value);

            //Räka hur många tärningar som matcha det valda nummer
            int winningDices = 0;
            if (dice1.Value == chosenNumber)
            {
                winningDices++;
            }
            if (dice2.Value == chosenNumber)
            {
                winningDices++;
            }
            if (dice3.Value == chosenNumber)
            {
                winningDices++;
            }

            if (winningDices > 0)
            {
                return (winningDices + 1) * bet;
            }
            return 0;
        }
    }
}
