namespace OhFortuna
{
    internal class Program
    {
        public static Json jsonconfig { get; set; } = new Json();
        public static void Main(string[] args)
        {
            Console.SetWindowSize(70, 25);
            Console.Title = "Oh Fortuna!";
            var Playing = true;
            var Running = true;
            var pix = 500;
            int choice = 0;
            int amount = 0;
            int match = 0;
            var Input = new Input();
            var gamelogic = new GameLogic();
            Visuals.StartGame();
            while (Running)
            {
                GameLogic.Menu(ref Playing, ref pix);
                while (Playing)
                {
                    Visuals.DrawPix(pix);
                    choice = Input.Choice(choice, pix);
                    amount = Input.Amount(amount, pix);
                    Visuals.DrawPix(pix);
                    match = gamelogic.RollDice(choice);
                    Visuals.DrawPix(pix);
                    gamelogic.Conditions(ref match, ref amount, ref pix);
                    Visuals.DrawPix(pix);
                    gamelogic.EndGame(ref pix, ref Playing, ref Running);
                }
            }
        }
    }
}