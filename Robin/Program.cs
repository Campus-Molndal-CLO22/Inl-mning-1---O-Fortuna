class program
{
    static void Main()
    {
        //Deklarera variabler för kontosaldo, satsning, bool för game loop, och lyckotalet man vill spela
        double account = 500;
        double bet = 0;
        bool play = true;
        int luckyNumber = 0;
        string inputValidation = "";

        //Game loop--------------------------------------------------------------------------------------------------------
        while (play == true)
        {
            // Återställer värden så att looparna kan köras igen om man väljer att spela en till runda
            bet = 0;
            luckyNumber = 0;

            // Satsa dina pengar
            bet = Bet(bet, account, inputValidation);

            // Välj lyckotal
            luckyNumber = ChooseNumber(luckyNumber, inputValidation);

            // Jämför lyckotalet mot tärningsuslaget och beräkna vinst/förlust
            account = CalculateWinnings(bet, luckyNumber, DiceResults(), account);

            // Kontrollera saldot så att man kan spela igen, och låter spelaren välja om man då vill spela eller avsluta
            play = AccountCheck(account, play);
        }
        // Game loop-------------------------------------------------------------------------------------------------------
    }

    // METODER-------------------------------------------------------------------------------------------------------------

    // Metod för att satsa pengar
    static double Bet(double bet, double account, string inputValidation)
    {
        // Kontrollera att satsningen är större än minimmum, men inte mer än vad som finns i account
        while (bet < 50 || bet > account)
        {
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine($"Your account balance is {account}");
            Console.WriteLine("Place bet, minimun 50");

            // Om input inte är av typen double, skriv ut ett felmeddelande
            try
            {
                bet = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Om satsningen är inom ramarna så bekräftas det, annars felmeddelande
            inputValidation = (bet < 50 || bet > account) ? "Invalid bet, please try again" : $"{bet} confirmed";
            Console.WriteLine(inputValidation);
        }
        return bet;
    }

    // Metod för att välja lyckotal
    static int ChooseNumber(int luckyNumber, string inputValidation)
    {
        // Kontrollera att lyckotalet är 1-6
        while (luckyNumber < 1 || luckyNumber > 6)
        {
            Console.WriteLine("Choose a number 1-6");

            // Om input inte är av typen int, skriv ut felmeddelande 
            try
            {
                luckyNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Om talet är inom ramarna så bekräftas det, annars felmeddelande
            inputValidation = (luckyNumber < 1 || luckyNumber > 6) ? "Invalid input, please try again" : $"{luckyNumber} confirmed";
            Console.WriteLine(inputValidation);
        }
        return luckyNumber;
    }

    // Metod för att generera Tärningsutslag
    static int[] DiceResults()
    {
        //Deklarera tärningsvariabeln och tärningsresultat i en array
        Random dice = new();
        int[] diceResults = new int[3];

        // Generera 3 utslag på tärningen
        for (int i = 0; i < diceResults.Length; i++)
        {
            diceResults[i] = dice.Next(1, 7);
        }

        // Returnera de 3 tärningarnas resultat
        return diceResults;

    }

    // Metod för att räkna ut eventuella vinster eller förluster
    static double CalculateWinnings(double bet, int luckyNumber, int[] diceResults, double account)
    {
        // winningsMultiplier håller koll på om du har vunnit och hur många gånger din vinst du får
        int winningsMultiplier = 1;
        Console.WriteLine($"bet [{bet}]");
        Console.WriteLine($"Your chosen number [{luckyNumber}]");

        // Skrver ut tärningsresultaten 
        for (int i = 0; i < diceResults.Length; i++)
        {
            Console.WriteLine($"The dice results {diceResults[i]}");

            //Kollar om tärningsresultatet är lika med lyckotalet, winningsMultipliern ökar med 1 för varje tal som är lika
            if (diceResults[i] == luckyNumber)
            {
                winningsMultiplier++;
            }
        }

        // Om winningsMultipler == 1 betyder det att ingen tärning har haft samma nummer som lyckotalet, förlusten beräknas och skickas tillbaka till game loop där variabeln account updateras
        if (winningsMultiplier == 1)
        {
            Console.WriteLine($"You lost {bet} \nYour account balance is now {account = account - bet}");

            return account;
        }
        // Om du har vunnit så räknas din vinst ut och skickas tillbaka till game loop där variabeln account updateras med din vinst
        else
        {
            Console.WriteLine($"You won {winningsMultiplier * bet}! \nYour account balance is now {account = account + (winningsMultiplier * bet)}");
            return account;
        }
    }

    // Metod för kontrollera saldot på ditt konto
    static bool AccountCheck(double account, bool play)
    {
        // Om värdet i kontot understiger minimum bet, avsluta 
        if (account < 50)
        {
            Console.WriteLine("You do not have sufficient funds to play again");
            return false;
        }
        // Annars välj om man vill spela igen eller avsluta
        else
        {
            Console.WriteLine("Press any key and \"Enter\" to play again, press \"n\" and \"Enter\" to stop");
            play = (Console.ReadLine().ToUpper() == "N") ? false : true;
            return play;
        }

    }
}
/*
    Uppgiften:
•-Spelaren startar med 500 pix
• Spelrunda:
o-Spelaren satsar pix(minst 50 pix)
o-Spelaren väljer ett lyckotal(1-6)
o-Tre T6-tärningar kastas
o-Om en tärning visar lyckotalet får man dubbla insatsen
o-Om två tärningar visar får man tre gånger insatsen
o-Om alla tärningarna visar lyckonumret så får man fyra gånger insatsen.
• Regler
o-Spelaren får inte satsa mer än vad denne har på banken
o-Spelaren får inte fuska och satsa negativa värden
o-Om spelarens konto understiger 50 pix avslutas spelet
o-Efter en runda får spelaren se sitt saldo och välja om denne vill köra en runda till

1.1 FÖR GODKÄNT SKA ALGORITMEN
1.-Köra en spelrunda enligt reglerna
2.-Låta spelaren välja att köra en runda till
3.-Visa spelaren saldo och tärningarnas resultat
4. Koden ska vara snyggt skriven och variablerna ska vara bra namngivna
5. Om spelaren anger ett felaktigt värde vid inmatning ska spelaren informeras om detta, men
programmet ska inte krascha
6. Projektet ska lagras på Github
*/
