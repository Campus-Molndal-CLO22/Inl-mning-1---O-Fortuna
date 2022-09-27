





// Deklarerar variabler
Random random = new Random();
int minBet = 50;
long spelarensPix = 500;
long spelarensBet = new();
long lyckotal = new();
string spelaIgenSvar = "";
bool spelaIgen = true;



while (spelaIgen) // En while loop som alltid är true så länge spelaren vill spela igen
{
    ReglerOchIntro();//Skriver ut Välkommen och regler
    spelarensBet = 0; // Återställer spelarens bet
    lyckotal = 0; //Återställer spelarens lyckotal

    Console.WriteLine($"Var god lägg ditt bet mellan { minBet}-{ spelarensPix}: "); // Ber spelaren lägga ett bet mellan 50 och vad spelaren har

    while (spelarensBet! <= minBet || spelarensBet! >= spelarensPix) // Kollar så att spelarens bet är OK
    {
        long.TryParse(Console.ReadLine(), out spelarensBet); // kollar så att spelaren skriver in en siffra

        if (spelarensBet >= minBet && spelarensBet <= spelarensPix) // Om spelarens bet är OK så breakar loopen
        {
            spelarensPix = spelarensPix - spelarensBet;
            RödText($"- {spelarensBet}");
            Console.WriteLine($"Ditt saldo : {spelarensPix} Ditt bet: {spelarensBet}");
            break;
        }
        else if (spelarensBet > spelarensPix) //Om spelaren bettar mer än vad spelaren har så säger den att det inte är OK och man får lägga ett nytt
        {
            Console.WriteLine($"Du kan inte lägga mer pix än vad du har({spelarensPix})!!");
            Console.WriteLine($"Var god lägg ditt bet mellan { minBet}-{ spelarensPix}: ");
        }
        else if (spelarensBet == 0) // Om spelaren skriven in ett superlångt tal eller en text får dom felaktig input som svar och blir ombedda att lägga ett nytt bet
        {
            Console.WriteLine("Felakting input");
            Console.WriteLine($"Var god lägg ditt bet mellan { minBet}-{ spelarensPix}: ");
        }
        else if (spelarensBet < minBet) // Om spelaren lägger ett bet som är mindre än minsta möjliga bet så säger programet det och ber spelaren lägga ett nytt bet
        {
            Console.WriteLine($"Du kan inte lägga mindre pix än {minBet}!!");
            Console.WriteLine($"Var god lägg ditt bet mellan { minBet}-{ spelarensPix}: ");
        }
        else
        {
            Console.WriteLine("Felakting input");
            Console.WriteLine($"Var god lägg ditt bet mellan { minBet}-{ spelarensPix}: ");
        }
    }

    Console.WriteLine("Välj ett 'Lyckotal' mellan 1-6"); // Ber personen välja ett lyckotal mellan 1-6

    while (lyckotal < 1 || lyckotal > 6) // Så länge lycktalet är lägre än 1 eller större än 6 körs en loop
    {
        long.TryParse(Console.ReadLine(), out lyckotal); // Kollar så att lyckotalet är en siffra

        if (lyckotal >= 1 && lyckotal <= 6) // Om lyckotalet är mellan 1-6 så breakar loopen
        {
            break;
        }
        else if (lyckotal > 6) // Om lyckotalet är större än 6 så ber programmet personen skriva in ett nytt lyckotal mellan 1-6
        {
            Console.WriteLine("Du kan inte välja ett 'Lyckotal' högre är 6");
            Console.WriteLine("Välj ett 'Lyckotal' mellan 1-6");
        }
        else if (lyckotal == 0) // Om personen skriver in text eller ett superlång nummber som inte int tar emot
                                // så svarar programmet "felaktig input" och ber personen skriva in ett nytt lyckotal
                                // Också om personen skriver in 0 så svarar programmet felaktig input
        {
            Console.WriteLine("Felaktig input");
            Console.WriteLine("Välj ett 'Lyckotal' mellan 1-6");
        }
        else if (lyckotal < 1) // Om lyckotalet är mindre än 1 så ber programmet personen lägga ett större bet
        {
            Console.WriteLine("Du kan inte välja ett 'Lyckotal' lägre än 1");
            Console.WriteLine("Välj ett 'Lyckotal' mellan 1-6");
        }
        else
        {
            Console.WriteLine("Felaktig input");
            Console.WriteLine("Välj ett 'Lyckotal' mellan 1-6");
        }

    }
     
    // Efter att spelaren valt lyckonummer så rullas tärnigarna
    int tärning1 = random.Next(1, 7);
    int tärning2 = random.Next(1, 7);
    int tärning3 = random.Next(1, 7);

   
    Console.WriteLine($"Tärnigar: {tärning1}, {tärning2}, {tärning3}"); // Tärningarna skrivs ut

    if (lyckotal == tärning1 && lyckotal == tärning2 && lyckotal == tärning3) // Om alla tärningar är samma som spelaren lyckotal vinner spelaren 4x sitt bet
    {
        spelarensPix = spelarensBet * 4 + spelarensPix;
        GrönText($"+ {spelarensBet * 4 }");
        GrönText($"Woow, Grattis du vann 4 x {spelarensBet}");
        GrönText($"Ditt saldo: {spelarensPix}");
    }
    
    else if (lyckotal == tärning1 && lyckotal == tärning2 || lyckotal == tärning1 && lyckotal == tärning3 || lyckotal == tärning2 && lyckotal == tärning3) 
    {//Om 2 tärningar är samma som lyckotalet vinner spelaren 2x sitt bet
        spelarensPix = spelarensBet * 3 + spelarensPix;
        GrönText($"+ {spelarensBet * 3 }");
        GrönText($"Grattis du vann 3 x {spelarensBet}");
        GrönText($"Ditt saldo: {spelarensPix}");
    }
    else if (lyckotal == tärning3 || lyckotal == tärning1 || lyckotal == tärning2) // Om bara en tärning stämmer så vinner spelaren 2x sitt bet
    {
        spelarensPix = spelarensBet * 2 + spelarensPix;
        GrönText($"+ {spelarensBet * 2 }");
        GrönText($"Grattis du vann 2 x {spelarensBet}");
        GrönText($"Ditt saldo: {spelarensPix}");
    }
    else // Om ingen tärning stämmer så säger programmet det
    {
        RödText("Tyvärr, ditt 'Lyckotal' stämde inte överens med någon tärning");
        RödText($"Ditt saldo: {spelarensPix}");
    }
    if (spelarensPix < minBet) //Om spelarensPix är mindre än 50 så berättar programmet att minsta bet är 50 och
                               //eftersom att spelaren inte har minst 50 pix kvar så avslutas programmet
    {
        RödText($"Du har tyvärr för lite pix kvar, minsta bet är {minBet}");
        Console.WriteLine("Vi ses en annan gång, då går det säkert bättre");
        Environment.Exit(0);
    }


    Console.WriteLine("Vill du spela igen? JA/NEJ"); // Frågar spelaren om denne vill spela igen
    spelaIgenSvar = Console.ReadLine().ToUpper(); // Tar emot spelarens svar och gör det till CAPS så att man kan skriva ja/nej hur man nu vill

    while (spelaIgenSvar != "JA" && spelaIgenSvar != "NEJ") // Om spelaren svarar något annat än ja/nej så ber programmet personen göra om och göra rätt
    {
        Console.WriteLine("Svara JA eller NEJ!");
        Console.WriteLine("Vill du spela igen? JA/NEJ");
        spelaIgenSvar = Console.ReadLine().ToUpper();
    }


    if (spelaIgenSvar == "JA" || spelaIgenSvar == "NEJ") // Om spelarens svar är Ja/Nej så körs en do
    {                                                   // Om spelaren väljer Ja till att spela igen så börjar while loopen om från början
        do
        {
            if (spelaIgenSvar == "NEJ") // Om spelaren svarar nej så avlustas programmet
            {
                if (spelarensPix < 500) // Om spelaren avslutar med mindre pix än vad spelaren startade med så tackar programmet för pixen
                {
                    Console.WriteLine("Okej, Tack för dina pix iallafall");
                    Environment.Exit(0);
                }
                else if (spelarensPix > 500) // Om spelaren avslutar med mer pix än vad spelaren startade
                                             // med så ber programmet spelaren komma och spela igen snart
                {
                    Console.WriteLine("Okej, men kom gärna tillbaka med mina pix en annan dag.");
                    Environment.Exit(0); 
                }
                spelaIgen = false;

            }
            Console.Clear();
            break;

        }
        while (spelaIgenSvar == "JA" || spelaIgenSvar == "NEJ");
    }

}

static void GrönText(string grönText)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(grönText);
    Console.ResetColor();

}

static void RödText(string rödText)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(rödText);
    Console.ResetColor();
}


static void ReglerOchIntro()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("+------------------------------------------+");
    Console.WriteLine("|         Välkommen till O FORTUNA         |");
    Console.WriteLine("+------------------------------------------+");
    Console.WriteLine();
    Console.WriteLine("+--------------------------------------------------------------------------+");
    Console.WriteLine("| I det här spelet börjar du med 500 pix och får betta minst 50 pix.       |");
    Console.WriteLine("| Därefter väljer du ett 'Lyckonummer' mellan 1-6, Sedan slår du 3         |");
    Console.WriteLine("| tärningar, får du dit lycka tal på en tärning får du 2x pixen,           |");
    Console.WriteLine("| två rätt på tärnigen så får du 3x pixen,eller alla tre rätt              |");
    Console.WriteLine("| på tärningarna så får du 4x pixen. Lycka till!!                          |");
    Console.WriteLine("+--------------------------------------------------------------------------+");
    Console.ResetColor();
}
























