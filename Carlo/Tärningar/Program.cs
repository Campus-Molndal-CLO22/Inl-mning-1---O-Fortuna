namespace Tärningar
{
    class Program
    {
        public static void Main(string[] args)
        {
            int pixPlånbok = 500;//Här deklarerar jag variabel Plånbok
            int pixInsats = 0;   //Här deklarerar jag variabel som visar hur my.cket man vill insatsa
            int dittVal = 0;    //Här deklarerar jag variabel som visar vilken nummer man väljer
            bool playing = true;//Här deklararer jag en variabel bool lika med true

            Console.WriteLine("+*********************************************************+");//Här sckikar jag på konsol
            Console.WriteLine("|*********************************************************|");//ett meddelande om "Wälkomenen
            Console.WriteLine("|***********Wälkommen till det magiska spelet*************|");//på spelet Oh Fortuna"
            Console.WriteLine("|***********************Oh Fortuna************************|");//
            Console.WriteLine("|*********************************************************|");//
            Console.WriteLine("+*********************************************************+");//

            while (playing)  //Här använder jag en loop while med variabel playing = true 
            {
                Console.WriteLine("Du har 500 pix i din plånbok");//Här visar jag på skärmen hur många pix du har i din plånbok
                Console.WriteLine("Välj en siffra mellan 1 och 6 : ");//Här visar jag till spelaren att välja ett nummer mellan 1 och 6
                while (true)// Jag skapar en loop while som verifierar om man ange en rätt nummer mellan 1 och 6 
                {
                    string x = Console.ReadLine();//Här skapar jag en "x" variabel som
                    int.TryParse(x, out dittVal);//omvandlar med tryParse och få i dittVal 
                    if (dittVal > 0 && dittVal < 7) break;//för att gemföra om är större en 0 och mindre en 7
                    else //annars
                    {
                        Console.Clear();//Med detta rensa jag skärmen
                        Console.WriteLine("Ange ett rätt nummer mellan 1 och 6");//Visar programmet på skärmen valet mellan 1 och 6 och gå ut från kontroll
                    }
                }
                Console.WriteLine($"Din pixPlånbok är: {pixPlånbok}");//Visar hur många pix finns i plånbok
                Console.WriteLine("Hur mycket vill du satsa :");//fråga hur mycket man vill satsa
                while (true)//Skapat loop som verifigera om insatsen är lika men inte mindre 50 pix och inte mer 
                {           // om man har i plånbok
                    string x = Console.ReadLine();//Här skapar jag variabel "x" som ge ut pixinsats
                    int.TryParse(x, out pixInsats);//som man verifierar att ......
                    if (pixInsats >= 50 && pixInsats <= pixPlånbok) break;//pixinsats mer och lika 50 men mindre o lika plånbok 
                    else
                    {

                        Console.WriteLine("Error!!!");//Om det stämmer inte visar på skärmen "error"
                        Console.WriteLine($"Du måste satsa minst 50 pix, högst {pixPlånbok}");//Påmina att måste vara minst 50 pix
                    }                                                                         //men inte mer än man har i plånbok
                }
                Console.WriteLine($"Du har valt nummer {dittVal} och satsat {pixInsats}");//Visar att man har valt lycko nummer och insats tot pix
                Random random = new();// Här skapar jag en random som kör för varje tärning som finns i lista
                List<int> tärning = new();// Här skapar jag en lista tärningar 
                tärning.Add(random.Next(1, 7));//Tärning 1 som generera en tal mella 1 och 6 via random
                tärning.Add(random.Next(1, 7));//Tärning 2 som generera en tal mella 1 och 6 via random
                tärning.Add(random.Next(1, 7));//Tärning 3 som generera en tal mella 1 och 6 via random
                Console.WriteLine("Nu rullar tärningarna!");//Programmet visar att tärningarna rullar
                for (int i = 0; i < tärning.Count; i++)//Här skapar jag en loop som startar från 1 till sista i lista
                {
                    Console.Write($"*{tärning[i]}* ");//Här visar på skärmer första tal som genererar första random i lista
                }
                int träffar = 0;//Här skapar jag variobel "träffa" och ge "0" för att verifigera om för varje tärningar är lika med 
                for (int i = 0; i < tärning.Count; i++)//talet som man väljer
                {
                    if (dittVal == tärning[i])//tärning 1
                        träffar++;//Nästan
                }
                if (träffar == 3)//Om träffar alle tre tärningar 
                {
                    pixPlånbok += pixInsats * 3;//Plånbok adderar 3 gånger vinsten (+insast*3)
                    Console.WriteLine($"Du fick tre träffar och du vann {pixInsats * 3} ");//Visar att träffa 3 gånger och vinsten är (pixinsats *3)
                    Console.WriteLine($"Ditt nya saldo är {pixPlånbok}");//Visar ny saldo
                }
                else if (träffar == 2)//Om träffar alle 2 tärningar 
                {
                    pixPlånbok += pixInsats * 2;//Plånbok adderars 2 gånger vinsten 
                    Console.WriteLine($"Du fick två träffar och du vann {pixInsats * 2} ");//Plånbok adderar 3 gånger och vinsten är(insast*3)
                    Console.WriteLine($"Ditt nya saldo är {pixPlånbok}");//Visar ny saldo
                }
                else if (träffar == 1)//Om träffar alle 1 tärningar 
                {
                    pixPlånbok += pixInsats;//Plånbok adderar vinsten + plånbok
                    Console.WriteLine($"Du fick en träff och du vann {pixInsats} ");//Visar att träffa en gång och vinsten är dubbelt
                    Console.WriteLine($"Ditt nya saldo är {pixPlånbok}");//Visar den nya saldo
                }
                else// Om man har inga träfft 
                {
                    pixPlånbok -= pixInsats;//Ta bart insatsen från plånbok 
                    Console.WriteLine($"Tyvärr du har otur denna gången!! Du förlorar {pixInsats}  ");//Det visar meddelande att man har otur och man har fårlorat insatsen
                    Console.WriteLine($"Ditt nya saldo är {pixPlånbok}");//Det visar nya saldo
                }
                if (pixPlånbok < 50)// Här kontrollerar om plånbok har mindre en 50 pix
                {
                    Console.WriteLine($"Spelet är över ");//Det visar att spelet är slut
                    Environment.Exit(0);//Spelet slutar
                }
                else//Annars gå vidare
                {
                    Console.WriteLine($"Vill du fortsätta spela?");//Här fråga om man vill fortsätta att spela
                    Console.WriteLine("1 för ja, 2 för nej");//Med 1 fortsätter man och med 2 slutar
                    int slutVal = 0;//Deklarera en variabel slutVal=0
                    while (true)//Loopen while är true
                    {
                    string x = Console.ReadLine();//Läsa string 'x' variabel
                    int.TryParse(x, out slutVal);//omvandlar med tryParse och få i slutVal 
                        if (slutVal == 2)//Loopen frågar ett val mellan 1 och 2 för att fortsätta eller sluta med 2 
                            Environment.Exit(0);//Class som ger möiljet att sluta programmet
                        else if (slutVal == 1)//Om man vill forsätta
                            break;
                        else
                            Console.WriteLine("Ange 1 eller 2");//Visar på skärmen valet 
                    }
                }
            }
        }
    }
}