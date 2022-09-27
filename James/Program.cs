internal class Program
{
    private static void Main(string[] args)
    {
        do
        {
            PlayGame();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nWould you play to play again? Y or N\n");
        } while (Console.ReadLine().ToLower() == "y");

    }

    static void PlayGame()
    {
            Console.WriteLine("Welcome to Dice\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("These are the rules: ");
            Console.ResetColor();
            Console.WriteLine("> Dice is a console game where you throw dices to gain points.");
            Console.WriteLine("> You throw 3 dices each round. Each roll that matches your lucky number awards you with points.");
            Console.WriteLine("> You start with 500 Pix. You win if you reach 2000 Pix and lose if you fall below 50 Pix.\n");
    
            int playerPix = 500;
            Console.WriteLine($"You have {playerPix} Pix.\n");

            Console.WriteLine("Enter lucky number, 1-6.");
            int luckyNr;

            do
            {
                Int32.TryParse(Console.ReadLine(), out luckyNr);
                if (luckyNr < 1 || luckyNr > 6)
                    Console.WriteLine("\nEnter a lucky number between 1 - 6.");
            } while (luckyNr < 1 || luckyNr > 6);

            Console.WriteLine($"Your lucky number is {luckyNr}.\n");
            System.Threading.Thread.Sleep(500);

            do
            {

                Console.WriteLine($"Place your bet, min. 50 Pix, max. {playerPix} Pix.");
                int betAmount;

                do
                {
                    Int32.TryParse(Console.ReadLine(), out betAmount);
                    if (betAmount < 50 || betAmount > playerPix)
                        Console.WriteLine($"Place a min bet of 50 Pix and a max bet of {playerPix}.");
                } while (betAmount < 50 || betAmount > playerPix);

                Console.WriteLine("You bet " + betAmount + " Pix.\n");

                Console.Write("Press any key to roll dices.\n");
                Console.ReadKey();

                Random r0 = new Random();
                Random r1 = new Random();
                Random r2 = new Random();

                int dice60 = r0.Next(1, 7);
                int dice61 = r1.Next(1, 7);
                int dice62 = r2.Next(1, 7);

                Console.WriteLine("\nYou rolled " + dice60 + ", " + dice61 + ", and " + dice62 + ".");

                if (dice60 == luckyNr && dice61 == luckyNr && dice62 == luckyNr)
                {
                    Console.WriteLine($"All three dices matches your lucky number {luckyNr}. \n");
                    Console.WriteLine("You win 4x bet amount");
                    playerPix += 4 * (betAmount);
                    Console.WriteLine("You now have " + playerPix + ".");

                }
                else if (dice60 == luckyNr && dice61 == luckyNr && dice62 != luckyNr)
                {
                    Console.WriteLine($"Two dices matches your lucky number {luckyNr}.\n");
                    Console.WriteLine("You win 3x bet amount.");
                    playerPix += 3 * (betAmount);
                    Console.WriteLine($"You now have {playerPix}.");
                }
                else if (dice60 == luckyNr && dice61 != luckyNr && dice62 == luckyNr)
                {
                    Console.WriteLine($"Two dices matches your lucky number {luckyNr}.\n");
                    Console.WriteLine("You win 3x bet amount.");
                    playerPix += 3 * (betAmount);
                    Console.WriteLine($"You now have {playerPix}.");
                }
                else if (dice60 != luckyNr && dice61 == luckyNr && dice62 == luckyNr)
                {

                    Console.WriteLine($"Two dices matches your lucky number {luckyNr}.\n");
                    Console.WriteLine("You win 3x bet amount.");
                    playerPix += 3 * (betAmount);
                    Console.WriteLine($"You now have {playerPix}.");
                }
                else if (dice60 == luckyNr || dice61 == luckyNr || dice62 == luckyNr)
                {
                    Console.WriteLine($"One dice matches your lucky number {luckyNr}.\n");
                    Console.WriteLine("You win 2x bet amount");
                    playerPix += 2 * (betAmount);
                    Console.WriteLine($"You now have {playerPix}.");
                }
                else
                {
                    Console.WriteLine($"No dices matches your lucky number {luckyNr}.\n");
                    Console.WriteLine("You lose bet.");
                    playerPix -= betAmount;
                    Console.WriteLine($"You now have {playerPix} Pix.");
                }

            if (playerPix >= 2000)
            {
                Console.WriteLine($"You have {playerPix} Pix and WIN the Game!\n");
                System.Threading.Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("WINNER!");
                Console.WriteLine("The rivers flow with wine and the air is thick of incense. Wealth is plentiful.");
                break;
            }
            else if (playerPix < 50)
            {
                Console.WriteLine($"You have less than {playerPix} Pix and LOSE the Game!\n");
                System.Threading.Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("LOSER!");
                Console.WriteLine("You got PIMP-slapped, lost all your Pix and spent the remainder of your days in an unconscious purple haze.");
            }
                
            } while (playerPix > 50);

            
    }


    }