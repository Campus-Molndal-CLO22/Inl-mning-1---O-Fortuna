using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tärning__inlämning_final
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region   Messages to the user.

            Console.WriteLine(" Welcome to Play'n' Pay ! ");
            Console.WriteLine(" Please charge your credit.");
            Thread.Sleep(500);
            Console.WriteLine(" Thank you ! Now you have 500 pix in your account.");
            Console.WriteLine(" How much pix would you like to invest on this round? ");
            Console.WriteLine(" Note: The minimum payment for each play is 50 Pix and you should not invest more than your credit. ");
            #endregion


            int balanceAccount;
            int.TryParse(Console.ReadLine(), out int investPix );

            while (investPix < 50 || investPix > 500)
            {
                Console.WriteLine(" Error! Enter the valid ammount ...");
                Console.WriteLine(" Note: The minimum payment for each play is 50 Pix and you shoud not invest more than your credit. ");
                
                int.TryParse(Console.ReadLine(), out investPix);

            }
            Console.WriteLine(" Thanks! You are allowed to continue...");
            balanceAccount = 500 - investPix;
            Console.WriteLine(" Now your balance account is : {0} pix", balanceAccount);


            do
            {
                Console.WriteLine(" Choose the lucky number and press the start button! ");
                Console.WriteLine(" Note: The lucky number must be between 1 to 6 ");
                //byte luckyNumber = Convert.ToByte(Console.ReadLine());

                byte.TryParse(Console.ReadLine(), out byte luckyNumber);

                while (luckyNumber>6 || luckyNumber<1)
                {
                    Console.WriteLine(" Enter the valid number! ");
                    //luckyNumber = Convert.ToByte(Console.ReadLine());
                    
                    byte.TryParse(Console.ReadLine(),out luckyNumber);
                }
                Random rand = new Random();
                byte die1 = (byte)rand.Next(1, 7);
                byte die2 = (byte)rand.Next(1, 7);
                byte die3 = (byte)rand.Next(1, 7);
                Console.WriteLine(" Die number one is : {0}", die1);
                Thread.Sleep(400);
                Console.WriteLine(" Die number two is : {0}", die2);
                Thread.Sleep(400);
                Console.WriteLine(" Die number three is : {0}", die3);
                Thread.Sleep(400);

                #region  Conditions

                if (die1 == luckyNumber && die2 != luckyNumber && die3 != luckyNumber)
                {
                    Console.WriteLine(" So far so good !");
                    int dubleInvetPix = 2 * investPix;
                    Console.WriteLine(" YOU WONE DOUBL THE BET :{0} ", dubleInvetPix);
                    balanceAccount = balanceAccount + dubleInvetPix;
                    Console.WriteLine(" Now your balance account is : {0} Pix", balanceAccount);
                }
                else if (die1 != luckyNumber && die2 == luckyNumber && die3 != luckyNumber)
                {
                    Console.WriteLine(" So far so good !");
                    int dubleInvetPix = 2 * investPix;
                    Console.WriteLine(" YOU WONE DOUBL THE BET :{0} ", dubleInvetPix);
                    balanceAccount = balanceAccount + dubleInvetPix;
                    Console.WriteLine(" Now your balance account is : {0} Pix", balanceAccount);
                }
                else if (die1 != luckyNumber && die2 != luckyNumber && die3 == luckyNumber)
                {
                    Console.WriteLine(" So far so good !");
                    int dubleInvetPix = 2 * investPix;
                    Console.WriteLine(" YOU WONE DOUBL THE BET :{0} ", dubleInvetPix);
                    balanceAccount = balanceAccount + dubleInvetPix;
                    Console.WriteLine(" Now your balance account is : {0} Pix ", balanceAccount);
                }
                else if (die1 == luckyNumber && die2 == luckyNumber && die3 != luckyNumber)
                {
                    Console.WriteLine(" Very good !");
                    int tripleInvestPix = 3 * investPix;
                    Console.WriteLine(" YOU WONE Tripel THE BET: {0}", tripleInvestPix);
                    balanceAccount = balanceAccount + tripleInvestPix;
                    Console.WriteLine(" Now your balance account is : {0} Pix ", balanceAccount);

                }
                else if (die1 == luckyNumber && die3 == luckyNumber && die2 != luckyNumber)
                {
                    Console.WriteLine(" Very good !");
                    int tripleInvestPix = 3 * investPix;

                    Console.WriteLine(" YOU WONE Tripel THE BET: {0}", tripleInvestPix);
                    balanceAccount = balanceAccount + tripleInvestPix;
                    Console.WriteLine(" Now your balance account is : {0} Pix", balanceAccount);
                }
                else if (die2 == luckyNumber && die3 == luckyNumber && die1 != luckyNumber)
                {
                    Console.WriteLine(" Very good !");
                    int tripleInvestPix = 3 * investPix;
                    Console.WriteLine(" YOU WONE Tripel THE BET: {0}", tripleInvestPix);
                    balanceAccount = balanceAccount + tripleInvestPix;
                    Console.WriteLine(" Now your balance account is : {0} Pix ", balanceAccount);
                }
                else if (die1 == luckyNumber && die2 == luckyNumber && die3 == luckyNumber)
                {
                    Console.WriteLine(" ****Excellent**** ");
                    int quadrupleInvestPix = 4 * investPix;
                    Console.WriteLine(" YOU WONE quadruple THE BET: {0} Pix ", quadrupleInvestPix);
                    balanceAccount = balanceAccount + quadrupleInvestPix;

                    Console.WriteLine(" Now your balance account is : {0} Pix ", balanceAccount);
                }
                else
                {
                    Console.WriteLine(" You were not lucky this time!");
                    Console.WriteLine(" Now your balance account is : {0} Pix", balanceAccount);
                }
                if (balanceAccount < 50)
                {
                    Console.WriteLine(" Your credit is not sufficient.The game is over!. ");
                    System.Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine(" Would you like to stop the game press N, otherwise press any key to continue.");
                    string answer = Console.ReadLine();
                    switch (answer)
                    {
                        case "N":
                        case "n":
                            Console.WriteLine("Good bye! Waiting to see you again...");
                            System.Environment.Exit(0);
                            break;
                    }
                    if (balanceAccount < 50 || answer == "n" || answer == "N")
                    {
                        Console.WriteLine(" Good bye! hope to see you soon! ");
                    }
                    else
                    {
                        Console.WriteLine(" Your balance account is {0} Pix", balanceAccount);
                        Console.WriteLine(" How much pix would you like to invest on this round? ");
                        Console.WriteLine(" Note: The minimum payment for each play is 50 Pix and you shoud not invest more than your credit. ");
                        
                        int.TryParse(Console.ReadLine(), out int investPix1);

                        #endregion

                        while (investPix1 < 50 || investPix1 > balanceAccount)
                        {
                            Console.WriteLine(" Error! Enter the valid ammount ...");
                            Console.WriteLine(" Note: The minimum payment for each play is 50 Pix and you shoud not invest more than your credit. ");
                            
                            int.TryParse(Console.ReadLine(), out investPix1);
                        }
                        Console.WriteLine(" Good luck , You are allowed to continue...");
                        balanceAccount = balanceAccount - investPix1;
                        Console.WriteLine(" Now your balance account is : {0} Pix ", balanceAccount);
                        investPix = investPix1;
                    }
                }
            } while (balanceAccount >= 0);
            Console.ReadKey();
        }
    }
}
