namespace DiceOfFortuna
{
    public class CheckInput

    {
        //Method that runs input from user and control that input is correct
        public static int MethodCheckInput(string question, int min, int max)
        {

            int userNumber;

            //why Do while!
            //In any case of this instance I always want it to run atleast once
            //Repeat only when the condition of the while is incorrect
            do
            {
                //Copy from Marcus (lektion)! Here we ask the user for a number and saves it in integer variable called "number"
                static int askUser(string question)
                {
                    int userNumber;
                    Console.WriteLine(question);
                    int.TryParse(Console.ReadLine(), out userNumber);
                    return userNumber;

                }
                //Here is were we add the user input to the outside "number" variable so we can check if the input is correct in the while.
                userNumber = askUser(question);


            } while (userNumber < min || userNumber > max); // Check conditions of true or false

            //saves the users input outside the loop to be able to use it after the loop is done
            return userNumber;

        }


    }
}
