int pix = 500, val, bet, ran1, ran2, ran3;
Random random = new();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Regler: Satsa pix på ditt nummer (minst 50)\nVälj ett nummer mellan 1 och 6");
Console.WriteLine("Tre tärningar slås\nVid 1 rätt: 2x\nVid 2 rätt: 3x\nVid 3 rätt: 4x");
Console.ForegroundColor = ConsoleColor.White;

spelaIgen:
Console.WriteLine($"Nuvarande saldo: {pix} pix");

Console.WriteLine("Skriv in hur mycket pix du vill satsa(minst 50)");

try { bet = Convert.ToInt32(Console.ReadLine()); }
catch
{
    MakeRed("Felaktig inmatning!");
    goto spelaIgen;
}

if (bet < 50)
{
    MakeRed("Du måste minst satsa 50 pix!");
    goto spelaIgen;
}
else if (bet > pix)
{
    MakeRed("Du har inte tillräckligt med pix!");
    goto spelaIgen;
}

felSvar1:
Console.WriteLine("Välj ett nummer mellan 1 - 6");

try { val = Convert.ToInt32(Console.ReadLine()); }
catch
{
    MakeRed("Skriv in ett nummer mellan 1 - 6!(endast heltal)");
    goto felSvar1;
}
if (val == 0 || val > 6)
{
    MakeRed("Skriv in ett nummer mellan 1 - 6!");
    goto felSvar1;
}

ran1 = random.Next(1, 7);
ran2 = random.Next(1, 7);
ran3 = random.Next(1, 7);
Console.WriteLine($"Dina nummer: {ran1}, {ran2}, {ran3}");

if (ran1 == val && ran2 == val && ran3 == val)
{
    pix = bet * 4 + pix - bet;
    MakeGreen($"Grattis du vann: {bet * 4} pix");
}
else if ((ran1 == val && ran2 == val) || (ran1 == val && ran3 == val) || (ran2 == val && ran3 == val))
{
    pix = bet * 3 + pix - bet;
    MakeGreen($"Grattis du vann: {bet * 3} pix");
}
else if (ran1 == val || ran2 == val || ran3 == val)
{
    pix = bet * 2 + pix - bet;
    MakeGreen($"Grattis du vann: {bet * 2} pix");
}
else
{
    pix = pix - bet;
    Console.WriteLine("Ingen vinst tyvärr");
}

if (pix < 50)
{
    Console.WriteLine("\nSlut på pix tack för att du spelade!");
    return;
}

felSvar2:
Console.WriteLine($"\nNuvarande saldo: {pix} pix");
Console.WriteLine("Vill du spela igen? y/n");

char svar = Console.ReadKey().KeyChar;

if (svar == 'y' || svar == 'Y')
{
    Console.Clear();
    goto spelaIgen;
}
else if (svar == 'n' || svar == 'N')
{
    Console.WriteLine($"\nTack för att du spelade, du går ut med {pix} pix!");
    return;
}
else
{
    MakeRed("\nAnge y eller n!\n");
    goto felSvar2;
}

void MakeRed (string red)
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine(red);
    Console.ForegroundColor = ConsoleColor.White;
}
void MakeGreen (string green)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(green);
    Console.ForegroundColor = ConsoleColor.White;
}