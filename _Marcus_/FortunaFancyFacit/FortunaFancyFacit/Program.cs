/*
Spelaren startar med 500 pix
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
using System.Drawing;

bool play = true;
int pix = 500;
Random random = new();
while (play)
{
    while (pix > 50)
    {
        // Start  round
        DisplayGameScreen();
        Console.SetCursorPosition(5, 10);
        Console.WriteLine("What's your lucky number?");
        int lucky = AskForNumber(min: 1, max: 6, left: 32, top: 10);
        DisplayGameScreen();
        Console.SetCursorPosition(5, 10);
        Console.WriteLine("What do you want to bet?");
        int bet = AskForNumber(min: 50, max: pix, left: 32, top: 10);
        pix -= bet;
        DisplayGameScreen();
        DisplayPix(3);
        int t1 = random.Next(1, 7);
        int t2 = random.Next(1, 7);
        int t3 = random.Next(1, 7);
        FakeDice(t1, t2, t3, lucky);
        int score = (t1 == lucky ? 1 : 0) + (t2 == lucky ? 1 : 0) + (t3 == lucky ? 1 : 0);

        Console.SetCursorPosition(7, 10);
        if (score == 0)
        {
            CenterText("You lost!!!");
        }
        else if (score == 1)
        {
            CenterText("You won " + bet * 2);
        }
        else if (score == 2)
        {
            CenterText("You won " + bet * 3);
        }
        
        if (score>0) pix += bet * (score + 1);
        DisplayPix(3);
        Console.CursorTop = 11;
        CenterText("Press [Enter] to proceed");
        Console.ReadLine();
    }
    DisplayGameScreen();
    Console.CursorTop = 11;
    CenterText("Do you want to lose again?");
    CenterText("1 - Yes");
    CenterText("2 - No ");
    int choice = AskForNumber(min: 1, max: 2, left: 10, top: 13);
    if (choice == 2) play = false;
    pix = 500;
}

int AskForNumber(int min, int max, int left, int top)
{
    int num = min - 1;
    while (num < min || num > max)
    {
        Console.SetCursorPosition(left, top);
        Console.Write("      ");
        Console.SetCursorPosition(left, top);
        string input = Console.ReadLine();
        int.TryParse(input, out num);
    }
    return num;
}

#region AsciiNumbers
string[] GetNumber(int num)
{
    string[] numbers = new string[4];
    foreach (char digit in num.ToString())
    {
        switch (digit)
        {
            case '0':
                numbers[0] += @"   ___   ";
                numbers[1] += @"  / _ \  ";
                numbers[2] += @" ( (_) ) ";
                numbers[3] += @"  \___/  ";
                break;
            case '1':
                numbers[0] += "  __  ";
                numbers[1] += " /  ) ";
                numbers[2] += "  )(  ";
                numbers[3] += " (__) ";
                break;
            case '2':
                numbers[0] += @"  ___   ";
                numbers[1] += @" (__ \  ";
                numbers[2] += @"  / _/  ";
                numbers[3] += @" (____) ";
                break;
            case '3':
                numbers[0] += (@"  ___  ");
                numbers[1] += (@" (__ ) ");
                numbers[2] += (@"  (_ \ ");
                numbers[3] += (@" (___/ ");
                break;
            case '4':
                numbers[0] += (@"   __   ");
                numbers[1] += (@"  /. |  ");
                numbers[2] += (@" (_  _) ");
                numbers[3] += (@"   (_)  ");
                break;
            case '5':
                numbers[0] += (@"  ___  ");
                numbers[1] += (@" | __) ");
                numbers[2] += (@" |__ \ ");
                numbers[3] += (@" (___/ ");
                break;
            case '6':
                numbers[0] += (@"   _   ");
                numbers[1] += (@"  / )  ");
                numbers[2] += (@" / _ \ ");
                numbers[3] += (@" \___/ ");

                break;
            case '7':
                numbers[0] += (@"  ___  ");
                numbers[1] += (@" (__ ) ");
                numbers[2] += (@"  / /  ");
                numbers[3] += (@" (_/   ");
                break;
            case '8':
                numbers[0] += (@"  ___  ");
                numbers[1] += (@" ( _ ) ");
                numbers[2] += (@" / _ \ ");
                numbers[3] += (@" \___/ ");
                break;
            case '9':
                numbers[0] += (@"  ___  ");
                numbers[1] += (@" / _ \ ");
                numbers[2] += (@" \_  / ");
                numbers[3] += (@"  (_/  ");
                break;
        }
    }
    return numbers;
}
#endregion


#region Display methods

void PrintDice(int row, int column, int value)
{
    string[] dice = GetDice(value);
    foreach (string dots in dice)
    {
        Console.SetCursorPosition(column, row++);
        Console.WriteLine(dots);
    }
}
void DisplayGameScreen()
{
    int max = Console.WindowWidth;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.SetCursorPosition(0, 0);
    CenterText("Fortuna Fancy Facit", max);
    Console.WriteLine($" +{new string('-', max - 4)}+");
    for (int row = 0; row < 25; row++)
    {
        Console.WriteLine($" |{new string(' ', max - 4)}|");
    }
    Console.WriteLine($" +{new string('-', max - 4)}+");
    Console.CursorTop = 0;
    DisplayPix(3);
    Console.ResetColor();
}

void DisplayPix(int pos)
{
    string[] nums = GetNumber(pix);
    var left = Console.WindowWidth - 3 - nums[0].Length;
    for (int top = 0; top < nums.Length; top++)
    {
        Console.SetCursorPosition(left, top + pos);
        Console.Write(nums[top]);
    }
}

void CenterText(string text, int max=-1)
{
    if (max == -1) max = Console.WindowWidth;
    int pos = (max - text.Length) / 2;
    if (pos < 0) pos = 0;
    Console.CursorLeft = pos;
    Console.WriteLine(text);
}

void FakeDice(int end1, int end2, int end3, int lucky)
{
    int pos = (Console.WindowWidth - 8 * 3) / 2; // 8 tecken per tärning, 3 tärningar
    for (int i = 0; i < 10; i++)
    {
        PrintDice(6, pos, random.Next(1, 7));
        PrintDice(6, pos + 8, random.Next(1, 7));
        PrintDice(6, pos + 16, random.Next(1, 7));
        System.Threading.Thread.Sleep(50);
    }
    Console.ForegroundColor = (lucky == end1 ? ConsoleColor.Yellow : ConsoleColor.Red);
    PrintDice(6, pos, end1);
    Console.ForegroundColor = (lucky == end2 ? ConsoleColor.Yellow : ConsoleColor.Red);
    PrintDice(6, pos + 8, end2);
    Console.ForegroundColor = (lucky == end3 ? ConsoleColor.Yellow : ConsoleColor.Red);
    PrintDice(6, pos + 16, end3);
    Console.ResetColor();
}
#endregion

#region AsciiDice
string[] GetDice(int number)
{
    string[] dice = new string[]
    {
        "+---+",
        "|   |",
        "|   |",
        "|   |",
        "+---+"
    };

    switch (number)
    {
        case 1:
            dice[2] = "| o |";
            break;
        case 2:
            dice[1] = "|o  |";
            dice[3] = "|  o|";
            break;
        case 3:
            dice[1] = "|o  |";
            dice[2] = "| o |";
            dice[3] = "|  o|";
            break;
        case 4:
            dice[1] = "|o o|";
            dice[3] = "|o o|";
            break;
        case 5:
            dice[1] = "|o o|";
            dice[2] = "| o |";
            dice[3] = "|o o|";
            break;
        case 6:
            dice[1] = "|o o|";
            dice[2] = "|o o|";
            dice[3] = "|o o|";
            break;
    }
    return dice;
}
#endregion
