namespace OhFortuna
{
    public class Visuals

    {
        /// <summary>
        /// Metod för att skapa en slumpningseffekt för tärningarna
        /// </summary>
        /// <param name="position"></param>
        public static void CasinoRoll(ref int position)
        {
            Console.SetCursorPosition(0, 0); Console.WriteLine("Rolling...");
            var casinoRoll1 = 0;
            var dice1 = true;

            while (dice1)
            {
                //  For loop för att "slumpa" fram ett nummer för tärningarna
                for (int i = 0; i < 7; i++)
                {
                    Console.SetCursorPosition(0, position); Console.Write(i);
                    Thread.Sleep(35);
                    //  Kontroll ifall variabeln casinoRoll1 är högre än 3, är den det så slutar den progressa
                    if (casinoRoll1 > 3)
                    {
                        break;
                    }
                    //  Kontroll ifall i nått 6, ifall den har det så lägg ställ in i till 0 igen och lägg till 1 i casinoRoll1
                    else if (i == 6)
                    {
                        i = 0;
                        casinoRoll1++;
                    }
                }
                break;
            }
        }
        /// <summary>
        /// Metod för att presentera animerad grafik när spelet startar
        /// </summary>
        public static void StartGame()
        {
            //  Skapar en Array för att kunna loopa igenom och skapa en animation
            string[] gameOver = new string[]
            {
                "||||||||||||||  |||||||||||||  |||\t     |||  |||||||||||||", "|||\t\t|||       |||  ||||         ||||  |||", "|||		|||       |||  |||||       |||||  |||",
                "|||\t\t|||\t  |||  ||||||\t  ||||||  |||", "|||   ||||||||  |||||||||||||  ||| |||   ||| |||  ||||||||", "|||\t   |||  |||       |||  |||  ||| |||  |||  |||",
                "|||\t   |||  |||       |||  |||   |||||   |||  |||", "||||||||||||||  |||       |||  |||    |||    |||  |||||||||||||"
            };
            //  Loop för att skriva ut och sudda ut Arrayen 2 gånger om
            for (int z = 0; z < 2; z++)
            {
                //  Skriver ut
                for (int x = 0; x < gameOver.Length; x++)
                {
                    Console.WriteLine(gameOver[x]);
                    Thread.Sleep(100);
                }
                //  Suddar ut
                for (int y = 0; y < gameOver.Length; y++)
                {
                    int currentLineCursor = Console.CursorTop;
                    Console.SetCursorPosition(0, y);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, currentLineCursor);
                    Thread.Sleep(100);
                }
                Console.SetCursorPosition(0, 0);
            }
        }
        /// <summary>
        /// Metod för att presentera en animerad gameover effekt
        /// </summary>
        public static void GameOver()
        {
            //  Skapar en Array för att kunna loopa igenom och skapa en animation
            string[] gameOver = new string[]
                {
                "||||||||||||||  |||||||||||||  |||\t     |||  |||||||||||||", "|||\t\t|||       |||  ||||         ||||  |||", "|||		|||       |||  |||||       |||||  |||",
                "|||\t\t|||\t  |||  ||||||\t  ||||||  |||", "|||   ||||||||  |||||||||||||  ||| |||   ||| |||  ||||||||", "|||\t   |||  |||       |||  |||  ||| |||  |||  |||",
                "|||\t   |||  |||       |||  |||   |||||   |||  |||", "||||||||||||||  |||       |||  |||    |||    |||  |||||||||||||", " ", "||||||||||||||  |||       |||  |||||||||||||||||  ||||||||||",
                "|||        |||\t|||       |||  |||                |||     |||", "|||\t   |||   |||     |||   |||                |||      |||", "|||        |||   |||     |||   ||||||||||         |||     |||",
                "|||        |||    |||   |||    |||                |||||||||", "|||        |||     ||| |||     |||                |||     |||", "||||||||||||||      |||||      |||||||||||||||||  |||      |||"
                };

            //  Loop för att skriva ut Arrayen
            for (int x = 0; x < gameOver.Length; x++)
            {
                Console.SetCursorPosition(0, x + 4); Console.WriteLine(gameOver[x]);
                Thread.Sleep(50);
            }

            //  Loop för att sudda ut Arrayen
            for (int y = 0; y < gameOver.Length; y++)
            {
                int currentLineCursor = Console.CursorTop;
                Console.SetCursorPosition(0, y + 4);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, currentLineCursor);
                Thread.Sleep(50);
            }
            Console.SetCursorPosition(0, 4);

            //  Loop för att skriva ut Arrayen
            for (int x = 0; x < gameOver.Length; x++)
            {
                Console.SetCursorPosition(0, x + 4); Console.WriteLine(gameOver[x]);
                Thread.Sleep(50);
            }
        }
        /// <summary>
        /// Metod för att presentera antal pix
        /// </summary>
        /// <param name="pix"></param>
        public static void DrawPix(int pix) //  Metod för att rita ut "Pix-Counter" rutan
        {
            Console.Clear();
            Console.SetCursorPosition(60, 0); Console.Write("┌─────┐");
            Console.SetCursorPosition(60, 1); Console.Write("│Pix: │");
            Console.SetCursorPosition(60, 2); Console.Write($"│       │");
            Console.SetCursorPosition(60, 3); Console.Write("└─────┘ \n");
            Console.SetCursorPosition(60, 2); Console.Write($" {pix}");
        }
    }
}