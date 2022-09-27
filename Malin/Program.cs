namespace Fortuna
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("          Välkommen till Fortuna!");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            Console.WriteLine("Här spelar vi på tärningar");
            Console.WriteLine("Varje spelomgång kostar minst 50 Pix");
            Console.WriteLine("Du startar med 500 Pix");
            int dinaPix = 500;

            while (dinaPix >= 50)
            {
                Console.WriteLine("Hur mycket vill du satsa?");

                int betPix = 0;
                while (true)
                {
                    string svarBet = Console.ReadLine();
                    if (int.TryParse(svarBet, out betPix))
                    {
                        if (betPix > 49 && betPix <= dinaPix) break;
                    }
                    Console.WriteLine("Felaktigt svar, läs instruktionerna och försök igen");
                }
                dinaPix = dinaPix - betPix;

                Console.WriteLine("Välj ett lyckotal mellan 1-6");
                Console.WriteLine("Sedan rullar vi de tre tärningarna och jämför resultatet med ditt tal");

                int lyckotal = 0;
                while (true)
                {
                    string input = Console.ReadLine();
                    Console.WriteLine("Intressant val!");
                    if (int.TryParse(input, out lyckotal))
                    {
                        if (lyckotal > 0 && lyckotal < 7) break;
                    }
                    Console.WriteLine("Du måste välja ett tal mellan 1 och 6, försök igen");
                }
                Random slumptal = new Random();

                int[] tärningar = new int[3];
                tärningar[0] = slumptal.Next(1, 7);
                tärningar[1] = slumptal.Next(1, 7);
                tärningar[2] = slumptal.Next(1, 7);

                Console.WriteLine($"Tärningarna är kastade och landade på:");
                Console.WriteLine($"{tärningar[0]}");
                Console.WriteLine($"{tärningar[1]}");
                Console.WriteLine($"{tärningar[2]}");
                Console.WriteLine();

                int antalRätt = 0;
                for (int i = 0; i < tärningar.Length; i++)
                {
                    if (tärningar[i] == lyckotal)
                    {
                        Console.WriteLine("Vinst på tärning nummer " + (i + 1));
                        antalRätt++;
                    }
                    else
                    {
                        Console.WriteLine("Ingen vinst på tärning nr " + (i + 1));
                    }
                }
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                int nyaPix = 0;
                if (antalRätt == 1)
                {
                    nyaPix = betPix * 2;
                    Console.WriteLine($"Hurra! Du vann {nyaPix} Pix");
                }
                else if (antalRätt == 2)
                {
                    nyaPix = betPix * 3;
                    Console.WriteLine($"Hurra! Du vann {nyaPix} Pix");
                }
                else if (antalRätt == 3)
                {
                    nyaPix = betPix * 4;
                }
                else Console.WriteLine("Det blev tyvärr ingen vinst den här gången");

                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                dinaPix = dinaPix + nyaPix;
                Console.WriteLine($"Du har nu {dinaPix} Pix kvar");

                if (dinaPix >= 50)
                {
                    Console.WriteLine("Tryck på valfri tangent för att spela en runda till. Tryck x för att avsluta");  
                                                                            
                    string spelaIgen = Console.ReadLine();
                    if (spelaIgen == "x") break;
                }
                else
                {
                    Console.WriteLine("Du har inte tillräckligt med Pix för att spela vidare");
                    break;
                }
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine(" Tack för att du spelade Fortuna! Hoppas vi ses snart igen ");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

        }
    }
}
