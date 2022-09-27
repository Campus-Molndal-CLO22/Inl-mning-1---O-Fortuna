using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ohfortuna
{
    internal class Player
    {
        public string name { get; }
        public int pixBalance { get; private set; }
        //Här skapar en ny spelare med 500 pix som startvärde
        public Player(string name)
        {
            this.name = name;
            this.pixBalance = 500;
        }

        //Här tar man bort pixbalansen när spelaren satsar
        public void DeductFromBalance(int amountToDeduct)
        {
            pixBalance -= amountToDeduct;
        }

        //Här lägger man till pix när spelaren har vunnit
        public void AddToBalance(int amountToAdd)
        {
            pixBalance += amountToAdd;
        }
    }

}
