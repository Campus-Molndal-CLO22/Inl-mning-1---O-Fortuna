namespace DiceGameAboutToLoseAllMyMoney2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine("|    Welcome to the Maple Casinos Dice Game  |");
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine("| Please select one of the following options |");
                Console.WriteLine("|         1. Start the Game                  |");
                Console.WriteLine("|         2. Read the Rules                  |");
                Console.WriteLine("|         3. Quit Game                       |");
                Console.WriteLine("+--------------------------------------------+");
                string inputMenu = Console.ReadLine();
                int menuChoice = 0;
                bool menuGuide = true;

                if (int.TryParse(inputMenu, out menuChoice))
                {
                    if (menuChoice == 1)
                    {
                        break;
                    }
                    else if (menuChoice == 2)
                    {
                        while (menuGuide)
                        {
                            Console.Clear();
                            Console.WriteLine("+--------------------------------------------+");
                            Console.WriteLine("|       Maple Casino Dice Game >Rules<       |");
                            Console.WriteLine("+--------------------------------------------+");
                            Console.WriteLine("|1. First of you pick your lucky number      |");
                            Console.WriteLine("|2. You place your bet. MINIMUM 50 Mesos     |");
                            Console.WriteLine("|3. The game will roll 5 dices               |");
                            Console.WriteLine("|4. You win different amount depending on    |");
                            Console.WriteLine("|   how many matching dices you get          |");
                            Console.WriteLine("|             |PRICEPOOL|                    |");
                            Console.WriteLine("|MATHCING DICE:  1x05 2x1.5 3x3 4x6 and 5x12 |");
                            Console.WriteLine("|When you got below 50 Mesos the game is over|");
                            Console.WriteLine("+---------PRESS ENTER TO CONTINUE------------+");
                            menuGuide = Console.ReadKey().Key != ConsoleKey.Enter;


                        }
                    }
                    else if (menuChoice == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Game is about to close");
                        for (int x = 0; x < 3; x++)
                        {

                            Console.WriteLine(".");
                            Thread.Sleep(2000);
                        }
                        Environment.Exit(0);

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("SAIK!");
                        Thread.Sleep(800);
                        Console.WriteLine("ITS THE WRONG NUMBER, TRY AGAIN!");
                        for (int x = 0; x < 3; x++)
                        {
                            Console.WriteLine(".");
                            Thread.Sleep(900);
                        }
                    }



                }

            }
            bool playing = true;
            double mesos = 500;

            while (playing)
            {





                Console.Clear();
                Console.WriteLine("+-----------------------------+");
                Console.WriteLine("|Pick a number between 1 and 6|");
                Console.WriteLine("+-----------------------------+");
                int numberChoice = 0;
                while (true)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out numberChoice))
                    {
                        if (numberChoice > 0 && numberChoice < 7) break;
                    }
                    Console.Clear();
                    Console.WriteLine("I strictly asked you to pick a number between 1 and 6");
                    Console.WriteLine($"and your dumbass picks {numberChoice}.. try again");

                }
                Console.WriteLine($"Good choice! How much would you like to bet? Minimum is 50 |>MESOS BALANCE:{mesos}|");

                int mesosAmount = 0;
                while (true)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out mesosAmount))
                    {
                        if (mesosAmount >= 50 && mesosAmount <= mesos) break;
                    }
                    Console.Clear();
                    Console.WriteLine($"WOOPS! You can't bet what you dont have! You only have {mesos} mesos and remember that the minimum bet is 50. TRY AGAIN! ");
                    Console.WriteLine("How much would you like to bet?");
                }
                Console.Clear();
                Random random = new();
                List<int> dice = new();// < > sätter vilken datatyp som man vill ha i listan i det här fallet en int
                dice.Add(random.Next(1, 7));
                dice.Add(random.Next(1, 7));
                dice.Add(random.Next(1, 7));
                dice.Add(random.Next(1, 7));
                dice.Add(random.Next(1, 7));


                Console.WriteLine($"You got the following dices {dice[0]}, {dice[1]}, {dice[2]}, {dice[3]}, {dice[4]}");


                int matchingDice = 0;
                for (int x = 0; x < dice.Count; x++)
                {
                    if (dice[x] == numberChoice)
                        matchingDice++;
                }
                if (matchingDice == 5)
                {
                    double five = 12;
                    mesos += mesosAmount * five;
                    Console.WriteLine($"HOLYBOLINGUS!! You got {matchingDice} matching Dices!!! you win {mesosAmount * five} Mesos!");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine($"Your new balance is {mesos} Mesos");
                }
                else if (matchingDice == 4)
                {
                    double four = 6;
                    mesos += mesosAmount * four;
                    Console.WriteLine($"WOW! You lucky guy, you got {matchingDice} matching dice you win {mesosAmount * four} Mesos!");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine($"Your new balance is {mesos} Mesos");
                }
                else if (matchingDice == 3)
                {
                    double three = 3;
                    mesos += mesosAmount * three;
                    Console.WriteLine($"You got {matchingDice} matching dice you win {mesosAmount * three} Mesos!");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine($"Your new balance is {mesos} Mesos");
                }
                else if (matchingDice == 2)
                {
                    double two = 1.5;
                    mesos += mesosAmount * two;
                    Console.WriteLine($"You got {matchingDice} matching dice you win {mesosAmount * two} Mesos!");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine($"Your new balance is {mesos} Mesos");
                }
                else if (matchingDice == 1)
                {
                    double one = 0.5;
                    mesos += mesosAmount * one;
                    Console.WriteLine($"You got {matchingDice} matching dice you win {mesosAmount * one} Mesos!");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine($"Your new balance is {mesos}  Mesos");
                }
                else
                {
                    mesos -= mesosAmount;
                    Console.WriteLine("Bahahaha! Do you even know how to play this game?");
                    Console.WriteLine($"Thank you very much for the {mesosAmount} Mesos!");
                    Console.WriteLine($"Your new balance is {mesos}");
                }
                if (mesos < 50)
                {
                    Console.WriteLine("Im so sorry but you dont have enough Mesos to continue playing");
                    Console.WriteLine($"Your current balance is {mesos} mesos");
                    Console.WriteLine("GAME OVER! Game is about to close");
                    for (int x = 0; x < 3; x++)
                    {
                        Console.WriteLine(".");
                        Thread.Sleep(2000);
                    }
                    playing = false;
                }
                else
                {
                    bool end = true;
                    while (end)
                    {
                        Console.WriteLine("+-------------------------------------------------+");
                        Console.WriteLine("|press 1 to play again or press 2 to quit the game|");
                        Console.WriteLine("+-------------------------------------------------+");
                        string inputMenu2 = Console.ReadLine();
                        int menuChoice2 = 0;
                        if (int.TryParse(inputMenu2, out menuChoice2))
                        {

                            if (menuChoice2 == 1)
                            {
                                playing = true;
                                end = false;
                            }
                            else if (menuChoice2 == 2)
                            {
                                Console.Clear();
                                Console.WriteLine("Game is about to close");
                                for (int x = 0; x < 3; x++)
                                {

                                    Console.WriteLine(".");
                                    Thread.Sleep(2000);
                                }
                                Environment.Exit(0);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("wrong character try again");

                            }


                        }

                    }


                }





            }





        }
    }
}