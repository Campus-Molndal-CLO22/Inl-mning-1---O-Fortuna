namespace Inlämning_Tärningar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlaynPlay();
        }

        static void PlaynPlay()
        {
            Console.WriteLine("+----------------------+");
            Console.WriteLine("+------OH FORTUNA!-----+");
            Console.WriteLine("+----------------------+\n");

            int pix = 500;
            Random random = new Random();

            while (pix >= 50)
            {
                int diceOne = random.Next(1, 7);
                int diceTwo = random.Next(1, 7);
                int diceThree = random.Next(1, 7);
                //Console.WriteLine(diceOne); // Om man vill fuska
                //Console.WriteLine(diceTwo);
                //Console.WriteLine(diceThree);

                void ShowDiceRoll() // Skapa en metod för att slippa skriva ut alla dessa rader inom varje if / else if statement nedan
                {
                    Console.WriteLine("Såhär slog tärningarna");
                    Console.WriteLine($"Tärning 1: {diceOne}");
                    Console.WriteLine($"Tärning 2: {diceTwo}");
                    Console.WriteLine($"Tärning 3: {diceThree}\n");
                }

                Console.WriteLine($"Ange hur mycket pix du vill satsa. Du har just nu {pix}pix!");
                Console.WriteLine("Du måste minst satsa 50pix per runda");

                string betString = Console.ReadLine();
                //Kan skriva såhär "int bet = Convert.ToInt32(Console.ReadLine());" annars,
                //men då vet jag inte hur jag ska göra så programmet ej krashar vid andra värden än int.
                int bet = 0;
                bool omSiffror = int.TryParse(betString, out bet);
                if (omSiffror)
                {
                    if (bet <= pix && bet >= 50)
                    {
                        Console.WriteLine("\nGrymt! Nu skall du välja ett lyckotal. Välj mellan 1-6:");

                        var lyckoTalString = Console.ReadLine();
                        Console.WriteLine();
                        int lyckoTal = 0;
                        bool omSiffrorTwo = int.TryParse(lyckoTalString, out lyckoTal);

                        if (omSiffrorTwo == true)
                        {
                            if (lyckoTal == 1 || lyckoTal == 2 || lyckoTal == 3 || lyckoTal == 4 || lyckoTal == 5 || lyckoTal == 6)
                            {
                                if ((lyckoTal == diceOne && lyckoTal != diceTwo && lyckoTal != diceThree) ||
                                (lyckoTal == diceTwo && lyckoTal != diceOne && lyckoTal != diceThree) ||
                                (lyckoTal == diceThree && lyckoTal != diceOne && lyckoTal != diceTwo))
                                // Antar att det finns ett bättre sätt att skriva detta på. Men detta var det ända jag kunde komma på.
                                {
                                    pix += bet * 2;
                                    Console.WriteLine($"Grattis du fick 1 rätt. Du vann just {bet * 2}pix!");
                                    ShowDiceRoll();
                                }
                                else if ((lyckoTal == diceOne && lyckoTal == diceTwo && lyckoTal != diceThree) ||
                                         (lyckoTal == diceOne && lyckoTal == diceThree && lyckoTal != diceTwo) ||
                                         (lyckoTal == diceTwo && lyckoTal == diceTwo && lyckoTal != diceOne))
                                {
                                    pix += bet * 3;
                                    Console.WriteLine($"Grattis du fick 2 rätt. Du vann just {bet * 3}pix!");
                                    ShowDiceRoll();
                                }
                                else if (lyckoTal == diceOne && lyckoTal == diceTwo && lyckoTal == diceThree)
                                {
                                    pix += bet * 4;
                                    Console.WriteLine($"WOW! Du fick alla rätt. Du vann just {bet * 4}pix!");
                                    ShowDiceRoll();
                                }
                                else if (lyckoTal != diceOne && lyckoTal != diceTwo && lyckoTal != diceThree)
                                {
                                    pix = pix - bet; // Försöker att skriva pix =- bet men då funkar det ej som jag vill
                                    Console.WriteLine($"Tyvärr du hade inga rätt... Du har nu {pix} kvar att betta");
                                    ShowDiceRoll();
                                }
                            }
                            else if (lyckoTal <= 0 || lyckoTal > 6)
                            {
                                Console.WriteLine("Du måste ange ett nummer mellan 1 och 6! Gör om.\n");
                            }

                            while (pix < 50)
                            {
                                Console.WriteLine("Du har förlorat :(");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Endast siffror är tillåtna. Gör om och skirv in ett nummer\n");
                        }

                    }
                    else
                    {
                        Console.WriteLine($"\nDu måste minst betta 50pix och som max {pix}pix\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nEndast siffror är tillåtna. Gör om och skirv in ett nummer\n");
                }
            }
        }
    }
}