namespace OhFortuna
{
    public class GameLogic
    {
        public static List<int> Dice { get; set; } = new List<int>();   //  Lista för tärningar
        /// <summary>
        /// Metod för att presentera startmenyn
        /// </summary>
        /// <param name="Playing"></param>
        /// <param name="pix"></param>
        public static void Menu(ref bool Playing, ref int pix)   //  Metod för att skapa menyn
        {
            Playing = true;
            Console.Clear();
            bool guide = true;
            bool startMenu = true;
            //  Loop för att kunna stanna i menyn och gå tillbaka i menyn så jag behöver
            while (startMenu)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0); Console.WriteLine($"Welcome to Oh Fortuna! \n" +
                    $"Make your choice \n" +
                    $"\t1 - Start playing\n" +
                    $"\t2 - Learn how to play\n" +
                    $"\t3 - View HiScores\n" +
                    $"\t4 - Exit Game");
                //  Switch cases för meny som använder sig av att läsa in keyboard input direkt.
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        startMenu = false;
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        while (guide)
                        {
                            Console.Clear();
                            Console.WriteLine($"Oh Fortuna is a dice based game\n" +
                                $"You will start with 500 pix \n" +
                                $"First you will be prompted to pick a lucky number between 1 - 6 \n" +
                                $"(Seeing as dice are T6's) \n \n" +
                                $"Right after that you will be asked the amount of pix you want to bet, \nyou can bet a minimum of 50\n" +
                                $"and a maximum of your total amount of pix\n \n" +
                                $"After you've chose your lucky number and amount to bet the \n" +
                                $"game starts rolling 3 dice, the more dice match your lucky number \n" +
                                $"the greater the reward. \n \n" +
                                $"If you end up with less than 50 pix it's game over\n \n" +
                                $"Press enter to return to the menu");
                            guide = Console.ReadKey().Key != ConsoleKey.Enter;
                        }
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Program.jsonconfig.HiScore(pix);
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        /// <summary>
        /// Metod för att rulla tärningarna och beräkna hur många som matchar ens "lucky number"
        /// </summary>
        /// <param name="choice"></param>
        /// <returns></returns>
        public int RollDice(int choice)
        {
            //  Sätter variabler och skapar tärningar.
            var position = 1;
            var rand = new Random(DateTime.Now.Millisecond);
            var match = 0;
            Dice.Clear();
            Dice.Add(rand.Next(1, 7));
            Dice.Add(rand.Next(1, 7));
            Dice.Add(rand.Next(1, 7));

            //  for loop för att presentera CasinoRoll Metoden och sedan mata in varje tärnings resultat, tills att x uppnått Dice.Count.
            for (int x = 0; x < Dice.Count; x++)
            {
                Visuals.CasinoRoll(ref position);
                Console.SetCursorPosition(0, x + 1); Console.Write(Dice[x]);
                position++;
            }
            //  for loop för att presentera punkter efter att tärningar presenterats.
            for (int x = 0; x < 3; x++)
            {
                Console.SetCursorPosition(0, x + 4); Console.Write(".");
                Thread.Sleep(500);
            }

            //  for loop för att kontrollera hur många tärningar som matchar
            for (int x = 0; x < Dice.Count; x++)
            {
                //  Kontrollerar om varje tärning matchar med ens val av nummer. Om den gör det så lägger den till 1 i "match" variabeln.
                if (Dice[x] == choice)
                    match++;
            }
            Console.Clear();
            return match;
        }
        /// <summary>
        /// Metod för att avgöra vilken "outcome" som ska presenteras
        /// </summary>
        /// <param name="match"></param>
        /// <param name="amount"></param>
        /// <param name="pix"></param>
        public void Conditions(ref int match, ref int amount, ref int pix) 
        {
            //  Om 3 tärningar matchar, lägg till visst antal pix baserat på ens insättning.
            if (match == 3)
            {
                pix += amount * match;
                Console.SetCursorPosition(0, 0); Console.WriteLine($"Jackpot!! You had {match} matching dice \n" +
                    $"You win: {amount * 4} pix \n" +
                    $"Your new balance is: {pix} pix");
            }
            //  Om 2 tärningar matchar, lägg till visst antal pix baserat på ens insättning
            else if (match == 2)
            {
                pix += amount * match;
                Console.SetCursorPosition(0, 0); Console.WriteLine($"Good guess! You had {match} matching dice \n" +
                    $"You win: {amount * 3} pix \n" +
                    $"Your new balance is: {pix} pix");
            }
            //  Om 1 tärningar matchar, lägg till visst antal pix baserat på ens insättning
            else if (match == 1)
            {
                pix += amount * match;
                Console.SetCursorPosition(0, 0); Console.WriteLine($"Victory! You had {match} matching dice \n" +
                    $"You win: {amount * 2} pix\n" +
                    $"Your new balance is: {pix}  pix");
            }
            //  Om ingen matchar, förlora insättning och fortsätt till slutkontroll.
            else
            {
                pix -= amount;
                Console.SetCursorPosition(0, 0); Console.WriteLine($"Darn it! You had {match} matching dice \n" +
                    $"Your loss is: {amount} pix\n" +
                    $"Your new balance is: {pix}  pix");
            }
            Thread.Sleep(3000);
        }
        /// <summary>
        /// Metod för att avgöra om spelet är över eller ska presentera en slutmeny för att spela igen exempelvis.
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="Playing"></param>
        /// <param name="Running"></param>
        public void EndGame(ref int pix, ref bool Playing, ref bool Running)
        {
            //  Om spelaren har mindre än 50 pix kvar, avsluta spel
            if (pix < 50)
            {
                int match = 0;
                int amount = 0;
                Conditions(ref match, ref amount, ref pix);
                Visuals.GameOver();
                Environment.Exit(0);
            }
            //  Annars, presentera menyval.
            else
            {
                bool switchEnd = true;
                while (switchEnd)
                {
                    Console.SetCursorPosition(0, 0); Console.WriteLine("Make your choice\n " +
                            "\t1 - Play again\n" +
                            "\t2 - Back to Menu\n" +
                            "\t3 - Submit score\n" +
                            "\t4 - Exit Game");
                    //  Switch meny som använder sig av direkt tangentinput för att avgöra vad som ska ske i menyn
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            switchEnd = false;
                            break;

                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            switchEnd = false;
                            Playing = false;
                            break;

                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            switchEnd = false;
                            Playing = false;
                            Program.jsonconfig.HiScore(pix);
                            break;

                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:
                            Environment.Exit(0);
                            break;
                    }
                    Console.Clear();
                }
            }
        }
    }
}