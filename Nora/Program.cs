namespace ohfortuna
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            //Skapa spelmotor
            Game game = new Game();

            //ASCII-hämtad från http://www.network-science.de/ascii/
            Console.WriteLine("\r\n  ___  _       _____          _                     \r\n / _ \\| |__   |  ___|__  _ __| |_ _   _ _ __   __ _ \r\n| | | | '_ \\  | |_ / _ \\| '__| __| | | | '_ \\ / _` |\r\n| |_| | | | | |  _| (_) | |  | |_| |_| | | | | (_| |\r\n \\___/|_| |_| |_|  \\___/|_|   \\__|\\__,_|_| |_|\\__,_|\r\n");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Welcome, please enter your name to play:");

            //Lägga in spelarens namn
            Player player = new Player(Console.ReadLine());

            //Skriva ut information på hur mycket man kan satsa
            Console.WriteLine("Welcome " + player.name + " you have " + player.pixBalance + " pix to play with.");

            //Minimum bet som man kan satsa
            Console.WriteLine("Minimum bet is 50 pix");

            //Spel loopen
            while (true)
            {
                Console.WriteLine("How many pix would you like to bet?");
                int bet = InputUtils.SafeReadInt("Place yout bet", 50, player.pixBalance);
                player.DeductFromBalance(bet);

                int chosenNumber = InputUtils.SafeReadInt("Choose your lucky number", 1, 6);

                //Spela en runda
                int winningAmount = game.PlayOneRound(chosenNumber, bet);
                player.AddToBalance(winningAmount);

                //Skriva ut hur mycket man har vunnit
                Console.WriteLine();
                if (winningAmount > 0)
                {
                    Console.WriteLine("Congratulations! " + player.name + " you have won " + winningAmount + " pix.");
                }

                //Hur mycket man har kvar efter en omgång
                Console.WriteLine(player.name + " you have now " + player.pixBalance + " pix.");

                //När pix balansen är under 50, Game over
                if (player.pixBalance < 50)
                {
                    Console.WriteLine(" _____                        _____                _ \r\n|  __ \\                      |  _  |              | |\r\n| |  \\/ __ _ _ __ ___   ___  | | | |_   _____ _ __| |\r\n| | __ / _` | '_ ` _ \\ / _ \\ | | | \\ \\ / / _ \\ '__| |\r\n| |_\\ \\ (_| | | | | | |  __/ \\ \\_/ /\\ V /  __/ |  |_|\r\n \\____/\\__,_|_| |_| |_|\\___|  \\___/  \\_/ \\___|_|  (_)");
                    Environment.Exit(0);
                }

                //Spela igen eller avsluta
                Console.WriteLine("Would you like to play again? Press any key or N to exit.");
                string playAgain = Console.ReadLine();
                if (playAgain.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }
        }
    }

}