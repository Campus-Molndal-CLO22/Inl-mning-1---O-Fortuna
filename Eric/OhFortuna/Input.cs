namespace OhFortuna
{
    public class Input
    {/// <summary>
    /// Metod för att spelaren ska kunna välja sitt "lucky number"
    /// </summary>
    /// <param name="choice"></param>
    /// <param name="pix"></param>
    /// <returns></returns>
        public int Choice(int choice, int pix) 
        {
            Console.SetCursorPosition(0, 0); Console.Write("Pick a number between 1 and 6: ");
            //  While loop som efterfrågar input och försöker göra om den till datatypen int, går det så matar den ut det till choice variabeln
            //  Därefter kontrollerar den om inputen är inom ramarna för en T6 tärning. Är den det så sätter den igång spelet, annars ger den
            //  errormeddelande och loopar om.
            while (true)
            {
                string input = Console.ReadLine();
                //  Här kontrolleras input och matas ut om det går.
                if (int.TryParse(input, out choice))
                {
                    //  Kontrollerar om input är inom ramarna.
                    if (choice > 0 && choice < 7) break;
                }
                Console.SetCursorPosition(0, 0); Console.WriteLine("Invalid number! Pick a number between 1 and 6:");
            }
            return choice;
        }
        /// <summary>
        /// Metod för att spelare ska kunna välja sin insats
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="pix"></param>
        /// <returns></returns>
        public int Amount(int amount, int pix) 
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Let's get started! \n" +
                $"Your current balance is: {pix} pix");
            Console.WriteLine("How much would you like to bet? (Minimum 50):");

            //  While loop som efterfrågar input och försöker göra om den till datatypen int, går det så matar den ut det till choice variabeln
            //  Därefter kontrollerar den om inputen är inom ramarna för spelreglerna. Är den det så sätter den igång spelet, annars ger den
            //  errormeddelande och loopar om.
            while (true)
            {
                string input = Console.ReadLine();
                //  Här kontrolleras input och matas ut om det går
                if (int.TryParse(input, out amount))
                {
                    //  Kontrollerar om input är inom ramarna
                    if (amount >= 50 && amount <= pix) break;
                }
                Visuals.DrawPix(pix);
                Console.SetCursorPosition(0, 0); Console.WriteLine("Invalid amount! State how much you would like to bet again: \n" +
                    $"Your balance is: {pix} pix");
            }
            Console.Clear();
            return amount;
        }
    }
}