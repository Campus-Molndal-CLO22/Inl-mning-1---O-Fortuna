namespace DiceOfFortuna

{
    public class Start
    {
        //Method to start the program and to get the choice to take diffrent paths.
        public static void MethodStart()
        {
            Console.WriteLine($"Welcome to Dice Of Fortuna");

            //we add the input method and saves that data in a new integer to check so user input correct values
            int choice = CheckInput.MethodCheckInput(
                $"---------------------------- \n" +
                $"What do you wanna do? \n" +
                $"Type 1 to play Fortuna! \n" +
                $"Type 2 to exit the game! \n" +
                $"----------------------------", 1, 2);

            //Switch to let user get a choice to run or exit the game
            switch (choice)
            {
                case 1:
                    if (choice == 1)
                        Run.MethodRun();
                    break;
                case 2:
                    if (choice == 2)
                        Exit.MethodExit();
                    break;
            }

        }
        //Same as above but with "Type 1 to play again" before it was "Type 1 to play Forune!"
        //and swaped so we don't reset the "run-loop" but says "Play again!!!" and runs the "run-loop" again.
        public static void MethodContinue()
        {
            int choice = CheckInput.MethodCheckInput(
                $"---------------------------- \n" +
                $"What do you wanna do? \n" +
                $"Type 1 to play again! \n" +
                $"Type 2 to exit the game! \n" +
                $"----------------------------", 1, 2);

            switch (choice)
            {
                case 1:
                    if (choice == 1)
                        Console.WriteLine("Play again!!!");
                    break;
                case 2:
                    if (choice == 2)
                        Exit.MethodExit();
                    break;
            }
        }

    }

}
