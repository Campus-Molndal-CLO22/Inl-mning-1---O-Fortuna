using System.Security.Cryptography.X509Certificates;

namespace DiceOfFortuna
{
    public class Run
    {

        public static void MethodRun()
        {
            //Added bank variable and set it to 500 starting value.
            int bankPix = 500;
            do
            {


                Console.WriteLine(
                   $"------------------------ \n" +
                   $"Your pix = {bankPix} \n" +
                   $"------------------------");

                //Check so you bet correct between 50 and your bank value, then save your bet value to integer.
                int myBet = CheckInput.MethodCheckInput("How much do you wanna bet? \n" +
                    $"Min bet 50 and you can't bet more then your bank allows!", 50, bankPix);

                //Remove your bet from the bank save it in myBet variable for later use
                bankPix -= myBet;

                //Check so you pick a number between 1-6 then saves that number to integer
                int userSelectedNumber = CheckInput.MethodCheckInput("Pick a number between 1-6", 1, 6);

                //Write the values from user inputs and add information to the user
                Console.WriteLine($"-------------------------- \n" +
                    $"Your bet is {myBet} \n" +
                    $"You picked number {userSelectedNumber} \n" +
                    $"And the 3 Dices are...");

                //Making one Array with 3 Random Numbers and then write em out in console.
                Random gameDice = new Random();

                //Saves the number of dices that was equal to user input.
                //Starting at 1 as we use this number to multiply the bet we made.
                int checkDiceToUserNumber = 1; 
                int[] dice = new int[3];
                for (int i = 0; i < dice.Length; i++)
                {
                    Console.WriteLine($"The Dice = {dice[i] = gameDice.Next(1, 7)}");

                    //Add how many times the dice was the same as your picked number
                    if (dice[i] == userSelectedNumber)
                    {
                        //This will be 1, 2, 3 or 4 depending on dice = user number 
                        checkDiceToUserNumber++;                                            
                    }
                    
                }

                //added integer to add winnings
                int betWon; 
                //String for the 3 diffrent winning to add later on in WriteLine
                string[] valueTimes = { "doubble", "tripple", "four times" };             

                //Here we check if the intiger is below value of 2. If so lose!
                if (checkDiceToUserNumber < 2)
                {
                    Console.WriteLine($"You lost! Your bank is now: {bankPix}");

                } else

                //Else statment to control the winnings
                //betWon there we add the bet * checkDiceToUserNumber (this is equal to 2-4 times)
                //We add the betWon to our bank
                {
                    betWon = myBet * checkDiceToUserNumber;

                    //Here we type the the string from above to type the correct winning statment.
                    //We use the "checkDiceToUserNumber" to get the correct array value.
                    //As the sum = 2 or more we have to add -2 so we start at 0 of the array.
                    Console.WriteLine($"Yay you {valueTimes[checkDiceToUserNumber - 2]} your bet. You won {betWon}");
                    bankPix += betWon;
                    Console.WriteLine($"Your bank is now: {bankPix}");
                }
                //method to play again and keep your bank intact
                Start.MethodContinue();

            } while (bankPix > 49); //Check if you lose the game!
            Console.WriteLine("You had no more pix in your bank... Game over!");
            Start.MethodStart(); //Method to get a choice to start a new game or exit
        }
       
    }

}
