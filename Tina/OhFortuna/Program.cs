class Program
{
    public static void Main()
    {   
        // Deklaration och tilldelning av variabler där balance= startvärde och gameOn ger användaren 
        // möjlighet att avsluta programmet
        int balance = 500,gameOn = 1;

        // Funktion som visar ett välkomstmeddelande
        Welcome();        

        // Loop som kör programmet tills användaren väljer att avsluta
        // gameOn sätter villkoret för att loopen ska fortsätta 
        while (gameOn != 2)
        {
            Console.Clear();

            // Hämtar insatsen, saldot skickas med för att kunna kontrollera
            // att giltigt värde angetts
            int bet = Bet(balance);      
            int luckyNumber = LuckyNumber();    // Hämtar spelarens valda lyckotal

            // Information om saldo och användarens val, för att det ska bli lättare för spelaren
            // att hänga med i vad som händer
            Console.WriteLine("Du har: "+balance+" pix");   
            Console.WriteLine("Insats: "+bet+" pix");
            Console.WriteLine("Ditt Lyckotal: "+luckyNumber);

            // Tärningarna rullas, resultatet beräknas och redovisas för användaren
            int matches = RollDices(luckyNumber);   
            int win = Result(matches, bet); 
            
            // Beräkning  och redovisning av saldo efter spelomgången
            balance += win;             
            Console.WriteLine("Du har nu: "+balance+" pix");
            Console.WriteLine();
             
            // Kontroll av saldo, är det mindre än 50 pix avslutas programmet automatiskt
            if (balance < 50)
            {
                Console.WriteLine("Du har inte tillräckligt med pix för att spela igen");
                break;
            }

            // Funktion som ger spelaren möjlighet att avsluta programmet
            gameOn = GameOn();
        }

        // Avskedshälsning
        Console.WriteLine("Välkommen åter!");
        Console.ReadLine();
    }

    // Välkomsthälsning
    static void Welcome()
    {
        Console.WriteLine(" Välkommen till Oh Fortuna! ");
        Console.WriteLine("============================");
        Console.WriteLine();
        Console.WriteLine("Välj ditt Lyckotal och låt tärningarna rulla!");
        Console.WriteLine();
        Console.WriteLine("Vinstplan: ");
        Console.WriteLine("1:a matchningen ger 2 X insatsen");
        Console.WriteLine("2:a matchningen ger 3 X insatsen");
        Console.WriteLine("3:e matchningen ger 4 X insatsen");
        Console.WriteLine();
        Console.WriteLine("För att hämta din välkomstbonus");
        Console.WriteLine("på 500 pix, tryck Enter: ");
        Console.ReadLine();
    }

    // Insats, loop som kör tills ett giltigt värde angetts och
    // ger felmeddelanden vid felaktig inmatning
    static int Bet(int balance)
    {
        int bet;
        Console.WriteLine("Du har "+balance+" pix");
        Console.WriteLine("Hur mycket vill du satsa? Minsta insats är 50 pix");
        do
        {
            int.TryParse(Console.ReadLine(), out bet);  // Kontrollerar att inmatningen är ett heltal
            if (bet < 50)
            {
                Console.WriteLine("Minsta insats är 50 pix");                
            }
            else if (bet > balance)
            {
                Console.WriteLine("Du kan inte satsa mer pix än du har");
            }
        } while (bet < 50 || bet > balance) ;   // Kontrollerar om insatsen uppfyller kraven
        return bet;
    }

    // Lyckotal, loop som körs tills ett giltigt värde angetts och
    // ger felmeddelande vid felaktig inmatning
    static int LuckyNumber()
    {
        int luckyNumber = 0;    // Lyckotalet ges startvärdet 0 för att starta loopen
        Console.WriteLine("Välj ett lyckotal mellan 1 och 6");
        while (luckyNumber < 1 || luckyNumber > 6)
        {
            int.TryParse(Console.ReadLine(), out luckyNumber);  // Kontrollerar om ett heltal angivits
            if(luckyNumber < 1 || luckyNumber>6)    // Kontrollerar om talet är inom angivna värden
                Console.WriteLine("Felaktig inmatning, välj ett tal mellan 1 och 6");            
        }
        Console.Clear();       
        return luckyNumber;
    }

    // 3 tärningar rullas och jämförs med valt lyckotal
    // Resultatet skrivs ut till skärmen
    static int RollDices(int luckyNumber)
    {
        Console.WriteLine();
        Random random = new();  // Initierar slumptalsgenerator
        int matches = 0;
        for(int i=0;i<3;i++)    // Styr antalet tärningar som rullas
        {
            int dice=random.Next(1,7);  // Ger ett slumptal mellan 1 och 6
            Console.WriteLine("Tärning "+(i+1)+" blev: "+dice);
            if(dice == luckyNumber)
                matches++;  
        }
        Console.WriteLine();
        return matches;     
    }

    // Beräknar och redovisar resultatet från spelomgången
    // Behöver parametrarna matches(antalet lika tärningar)
    // och bet(spelarens insats) 
    static int Result(int matches, int bet)
    {
        int win = 0;
        if (matches > 0)
        {
            win = bet + bet * matches;
            Console.WriteLine("Grattis!");
            Console.WriteLine("Du vann "+win+" pix!");
            Console.WriteLine();
        }
        else
        {
            win -= bet;
            Console.WriteLine("Ingen vinst den här gången!");
            Console.WriteLine();
        }
        return win;
    }

    // Loop som ger användaren valet att fortsätta spela eller avsluta programmet
    // Loopen kör tills giltigt val har gjorts
    static int GameOn()
    {
        Console.WriteLine("Välj: ");        // Presenterar de olika valen för användaren
        Console.WriteLine("1:Fortsätt");
        Console.WriteLine("2:Avsluta");
        int playAgain = 0;                  // playAgain sätts till 0 för att while-loopen ska starta
        int gameOn=0;
        while (playAgain != 1 && playAgain != 2)
        {
            int.TryParse(Console.ReadLine(), out playAgain);    // Kontrollerar om talet är ett heltal
            if (playAgain == 1) // if-satser som styr vad som händer om användaren väljer 1 eller 2
            {
                gameOn = 1;
            }
            else if (playAgain == 2)     
            {
                gameOn =  2;
            }
            else                // Skriver ut felmeddelande om användaren trycker något annat       
            {
                Console.WriteLine("Felaktigt val");
                playAgain=0;    
            }
        }
        return gameOn;
    }
}
    

 
