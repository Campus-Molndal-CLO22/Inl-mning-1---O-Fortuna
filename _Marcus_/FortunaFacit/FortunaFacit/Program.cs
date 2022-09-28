/*
 Spelbolaget Play’n’Pay behöver en bra algoritm för att skapa ett Fortuna-spel till sina spelmaskiner.
Så för att testa om spelet fungerar som den ska, ska vi skriva kod för det.
Spelet använder valutan pix.
Uppgiften:
• Spelaren startar med 500 pix
• Spelrunda:
o Spelaren satsar pix (minst 50 pix)
o Spelaren väljer ett lyckotal (1-6)
o Tre T6-tärningar kastas
o Om en tärning visar lyckotalet får man dubbla insatsen
o Om två tärningar visar får man tre gånger insatsen
o Om alla tärningarna visar lyckonumret så får man fyra gånger insatsen.
• Regler
o Spelaren får inte satsa mer än vad denne har på banken
o Spelaren får inte fuska och satsa negativa värden
o Om spelarens konto understiger 50 pix avslutas spelet
o Efter en runda får spelaren se sitt saldo och välja om denne vill köra en runda till

1.1 FÖR GODKÄNT SKA ALGORITMEN
1. Köra en spelrunda enligt reglerna
2. Låta spelaren välja att köra en runda till
3. Visa spelaren saldo och tärningarnas resultat
4. Koden ska vara snyggt skriven och variablerna ska vara bra namngivna
5. Om spelaren anger ett felaktigt värde vid inmatning ska spelaren informeras om detta, men
programmet ska inte krascha
6. Projektet ska lagras på Github
*/

int pix = 500;
bool play = true;
while (play)
{
    Console.Clear();
    Console.WriteLine($"Du har {pix} pix kvar");

    // Fråga användare om hur mycket denne vill satsa
    int bet = 0;
    while (bet < 50 || bet > pix)
    {
        Console.WriteLine("Hur mycket vill du satsa?");
        int.TryParse(Console.ReadLine(), out bet);
    }
    // Fråga användare om vilket lyckotal denne vill spela på
    int luckyNumber = 0;
    while (luckyNumber < 1 || luckyNumber > 6)
    {
        Console.WriteLine("Vilket lyckotal vill du spela på?");
        int.TryParse(Console.ReadLine(), out luckyNumber);
    }
    // Uppdatera saldo
    pix -= bet;

    // Kasta tärningar
    Random rnd = new Random();
    int[] dice = new int[3];
    dice[0] = rnd.Next(1, 7);
    dice[1] = rnd.Next(1, 7);
    dice[2] = rnd.Next(1, 7);
    Array.Sort(dice);
    
    // Visa resultatet
    Console.WriteLine($"Tärning 1: {dice[0]}");
    Console.WriteLine($"Tärning 2: {dice[1]}");
    Console.WriteLine($"Tärning 3: {dice[2]}");
    // Beräkna vinst
    // kontrollera antal matchningar
    // 1 matchning = dubbla insatsen
    // 2 matchningar = tre gånger insatsen
    // 3 matchningar = fyra gånger insatsen

    int win = 0;
    // Tärning0 == Tärning1 och Tärning1 == Tärning2 och Tärning2 == lyckotal
    if (dice[0] == dice[1] && dice[1] == dice[2] && dice[2] == luckyNumber)
    {
        win = bet * 4; // Full pott
    }
    // tärning0 == tärning1 och tärning1==lyckotal eller tärning1==tärning och tärning2==lyckotal
    else if (dice[0] == dice[1] && dice[1] == luckyNumber 
            || dice[1] == dice[2] && dice[2] == luckyNumber
            || dice[0] == dice[2] && dice[2] == luckyNumber)
    {
        win = bet * 3; // två träffar
    }
    // Om tärning0 == lyckotal eller tärning1 == lyckotal eller tärning3 == lyckotal
    else if (dice[0] == luckyNumber || dice[1] == luckyNumber || dice[2] == luckyNumber)
    {
        win = bet * 2; // en träff
    }
  

    // visa vinsten
    if (win>0)
        Console.WriteLine($"Du vann {win} pix");
    else
        Console.WriteLine("Du vann inte ett pix!");

    // uppdatera saldo
    pix += win;

    // fråga användare om denne vill spela igen
    Console.WriteLine($"Du har {pix} pix kvar");
    if (pix < 50)
    {
        Console.WriteLine("Du har för lite pix kvar för att spela igen");
        play = false;
    }
    else
    {
        Console.WriteLine("Vill du spela igen? (j/n)");
        string answer = Console.ReadLine();
        if (answer == "n")
        {
            play = false;
        }
    }
}