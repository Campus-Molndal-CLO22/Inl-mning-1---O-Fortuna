namespace OhFortuna
{
    internal class Program
    {
        public static void Main()
        {
            while (true)      //Spelstartloop     // Loop för reset av bank.
            {
                Console.WriteLine("Välkommen till Oh Fortuna!");
                int pix = 500;                                     // Startpix i banken.


                while (true)    // Loop för ny runda, fast samma bank som tidigare runda.
                {

                    Console.WriteLine("\nHur många pix vill du satsa? Du har just nu " + pix.ToString() + " att använda! (Du måste satsa minst 50 pix!)");
                    int insättning = 0;
                    while (insättning == 0 && (!int.TryParse(Console.ReadLine(), out insättning) || insättning < 49 || insättning > pix))            // Du måste satsa över 49 och under eller lika mycket pix som du har.
                    {
                        insättning = 0;  // reset så att vi får en ny chans o göra en valid input :)
                        Console.WriteLine("\nDu måste satsa en positiv summa på minst 50 pix och under " + pix.ToString() + " pix!\n");
                    }



                    Console.WriteLine("\nVälj ditt lyckotal från 1 - 6: ");         // Välj lyckotal mellan 1 - 6 då vi kör med 6 sidor tärning.
                    int Lyckotal = 0;     // reset så att vi får en ny chans o göra en valid input :)
                    while (Lyckotal == 0 && (!int.TryParse(Console.ReadLine(), out Lyckotal) || Lyckotal <= 0 || Lyckotal >= 7))
                    {
                        Lyckotal = 0;
                        Console.WriteLine("\nDu måste välja ett lyckotal från 1 - 6!!");
                    }


                    Console.WriteLine("\nTärningarna kastas!");    // Tärningskastkod och resultatlistning nedan :)
                    int maxRoll = 6;
                    int minRoll = 1;
                    Random random = new Random();
                    int Dice1 = random.Next(minRoll, maxRoll + 1);
                    int Dice2 = random.Next(minRoll, maxRoll + 1);
                    int Dice3 = random.Next(minRoll, maxRoll + 1);
                    //Följande kodrad(43, 44) är inspirerad av: https://stackoverflow.com/questions/64305668/how-to-check-how-many-times-an-item-exists-in-list-in-c  och  https://www.progsharp.se/kapitel/7/
                    Dictionary<int, int> DiceRollVärden = new List<int>()
                    {Dice1, Dice2, Dice3 }.GroupBy<int, int>((Func<int, int>)(n => n)).ToDictionary<IGrouping<int, int>, int, int>((Func<IGrouping<int, int>, int>)(g => g.Key), (Func<IGrouping<int, int>, int>)(g => g.Count<int>()));  //för att kunna checka förekomst. 



                    Console.WriteLine("\nTärningarna rullade " + Dice1.ToString() + " & " + Dice2.ToString() + " & " + Dice3.ToString() + "!");
                    int Förekomst;
                    if (!DiceRollVärden.TryGetValue(Lyckotal, out Förekomst))
                        Förekomst = 0;
                    if (Förekomst == 0)
                    {
                        Console.WriteLine("Ingen av tärningarna matchade ditt lyckotal " + Lyckotal.ToString() + ", du förlorade hela insättningen!");
                        pix -= insättning;                                                                                                                           //Förlorar hela insättningen vid 0 lyckotalförekomster.
                        Console.WriteLine("Ditt nya pix-saldo är " + pix.ToString() + "!");
                    }
                    if (Förekomst == 1)
                    {
                        Console.WriteLine("1 av tärningarna matchade ditt lyckotal " + Lyckotal.ToString() + "! Du vann din din insättning gånger 2!");
                        pix += insättning;                                                                                                                          // Vinner insättning * 2 vid 1 lyckotalförekomst.
                        Console.WriteLine("Ditt nya pix-saldo är " + pix.ToString() + "!");
                    }
                    if (Förekomst == 2)
                    {
                        Console.WriteLine("2 av tärningarna matchade ditt lyckotal " + Lyckotal.ToString() + "! Du vann din din insättning gånger 3!");
                        pix += insättning * 2;                                                                                                                      // Vinner insättning * 3 vid 2 lyckotalsförekomster.
                        Console.WriteLine("Ditt nya pix-saldo är " + pix.ToString() + "!");
                    }
                    if (Förekomst == 3)
                    {
                        Console.WriteLine("Alla 3 tärningarna matchade ditt lyckotal " + Lyckotal.ToString() + "!!! Du vann din din insättning gånger 4! JACKPOT!");
                        pix += insättning * 3;                                                                                                                      // Vinner insättning * 4 vid 3 lyckotalsförekomster. JACKPOT!
                        Console.WriteLine("Ditt nya pix-saldo är " + pix.ToString() + "!");
                    }


                EndofGameMeny:
                    int EndofGameMenyVal = 0;                               // Spelet är klart, slutmenyn startar här. 1 För att spela igen. 2 För att resetta. 3 För att avsluta. 322 För EASTER EGG fusk.
                    while (true)
                    {
                        Console.WriteLine("\nDu har spelat klart rundan och har nu " + pix.ToString() + " pix i banken. \nVad vill du göra? (Skriv siffran som matchar ditt val!) \n [1]. Spela en till runda. \n [2]. Resetta spelet. (Börja om med 500 pix) \n [3]. Avsluta spelet.\n");
                        while (EndofGameMenyVal == 0)
                        {
                            if (int.TryParse(Console.ReadLine(), out EndofGameMenyVal))
                            {
                                if (EndofGameMenyVal < 4 && EndofGameMenyVal > 0)
                                {
                                    break;
                                }

                                if (EndofGameMenyVal == 322)       //easter egg :)
                                {
                                    break;
                                }

                            }

                            EndofGameMenyVal = 0;      // reset så att vi får en ny chans o göra en valid input :)
                            Console.WriteLine("Du måste välja 1, 2 eller 3!!!");
                        }


                        while (EndofGameMenyVal == 1)     // Spela igen, failar om du inte har minst 50 pix så att du faktiskt kan spela.
                        {
                            if (pix < 50)
                            {
                                Console.WriteLine("\nDu kan inte spela en till runda, du har bara kvar " + pix.ToString() + " pix och du behöver minst 50 pix! \nResetta spelet med [2] eller avsluta med [3]!\n");
                                goto EndofGameMeny;
                            }
                            if (pix > 49)
                            {
                                break;
                            }
                        }


                        while (EndofGameMenyVal == 2)
                        {
                            goto ResetSpel;             // Skickar dig till den första whileloopen som alla andra loops är nestade i för restart.
                        }

                        while (EndofGameMenyVal == 3)        // <<<<<<< Exit Here
                        {
                            while (true)
                            {
                                Console.WriteLine("Är du säker? Y/N");              // Kolla så att spelaren inte "råkar" quitta.
                                string quit = Console.ReadLine();

                                if (quit == "Y")
                                {
                                    Environment.Exit(0);
                                }
                                if (quit == "N")
                                {
                                    goto EndofGameMeny;
                                }
                                else
                                {
                                    Console.WriteLine("Du måste välja Y / N !");
                                }
                            }
                        }


                        while (EndofGameMenyVal == 322)          // hemlis
                        {
                            Console.WriteLine("Jasså, du fuskar alltså?\n");
                            if (Console.ReadLine() == "Ja")
                            {
                                Console.WriteLine("Okej då...\n");
                                Console.ReadLine();
                                pix += 1337;
                                Console.Clear();
                                goto EndofGameMeny;
                            }
                            else
                            {
                                Console.WriteLine("Grattis du fuska dig till att ha endast 1 pix i banken, bara att resetta eller ge upp.");
                                Console.ReadLine();
                                pix = 1;
                                Console.Clear();
                                goto EndofGameMeny;
                            }
                        }


                        Console.Clear();
                        break;
                    }
                }
            ResetSpel:
                Console.Clear();
            }
        }
    }
}                                                            // SLUTKOMMENTAR: Lagt in många \n för att det ska se bättre ut för användaren även om koden ser värre ut lol