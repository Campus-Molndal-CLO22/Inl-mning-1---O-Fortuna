int pixBalance = 500;

Console.WriteLine("---------------------------");
Console.WriteLine("Välkommen till  OH FORTUNA ");
Console.WriteLine("---------------------------");

while (pixBalance >= 50)
{
    Console.WriteLine("Balance: " + pixBalance);
    Console.WriteLine("Hur mycket vill du satsa? (minst 50)");

    int.TryParse(Console.ReadLine(), out int pixBet);
    if (pixBet < 50)
    {
        Console.WriteLine("Du satsar för lite pix");
    }
    else if (pixBet > pixBalance)
    {
        Console.WriteLine("Du kan inte satsa mer pix än du har.");
    }
    else
    {
        pixBalance = pixBalance - pixBet;
        Console.WriteLine("Välj ett lyckotal mellan 1-6");
        int.TryParse(Console.ReadLine(), out int lyckonummer);
        if (lyckonummer <= 0 || lyckonummer >= 7)
        {
            Console.WriteLine("Mellan 1-6");
        }
        else
        {
            Random random = new Random();

            int[] tärningar = new int[3];

            tärningar[0] = random.Next(1, 7);
            int multiplier = 0;

            for (int i = 0; i < tärningar.Length; i++)
            {
                tärningar[i] = random.Next(1, 7);
                Console.WriteLine(tärningar[i]);
                if (tärningar[i] == lyckonummer)
                {
                    multiplier++;
                }
            }
            if (multiplier == 0)
            {
                Console.WriteLine("Inga rätt. Du förlorade pixen");
                Console.WriteLine("Vill du spela igen? Klicka ESC för att avsluta och valfri tangent för att spela igen:");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }

            }
            else
            {
                Console.WriteLine("Du hade rätt på " + multiplier + " tärningar och får " + (multiplier+1) + "x betalt");
                pixBalance = pixBalance + (pixBet * (multiplier + 1));
                Console.WriteLine("Vill du spela igen? Klicka ESC för att avsluta och valfri tangent för att spela igen:");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }



            }
                                   
        }
    }
}