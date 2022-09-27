using Newtonsoft.Json;
using static System.Formats.Asn1.AsnWriter;

namespace OhFortuna
{
    internal class Json
    {
        //  Prop för Path till LuckyNumberScore.json
        public static string Path { get; set; } = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LuckyNumberScore.json");
        /// <summary>
        /// Metod för att initiera Json klassen.
        /// </summary>
        public Json() {
            //  Ifall inte sparfilen finns, skapa en.
            if (!File.Exists(Path))
            {
                var filetype = new List<Score>();
                var jsonInput = JsonConvert.SerializeObject(filetype);
                File.WriteAllText(Path, jsonInput);
            } 
        }

        /// <summary>
        /// GetScore Lista
        /// </summary>
        /// <returns>Returnerar en lista av scores</returns>
        public  List<Score> GetScore() => JsonConvert.DeserializeObject<List<Score>>(File.ReadAllText(Path));
        /// <summary>
        /// Metod för att spara score till sparfilen.
        /// </summary>
        /// <param name="name">Player name</param>
        /// <param name="pix">Player pix</param>
        public void SaveScore(string name, int pix)
        {
            //  Importerar HiScore listan till variabel "scores"
            var scores = GetScore();
            //  Lägger till score i listan
            scores.Add(new Score() { Name = name, Pix = pix });
            //  Sorterar listan, högst till lägst.
            scores = scores.OrderByDescending(x => x.Pix).ToList();

            //  Skapar en ny variabel där scores serializas till json format.
            var jsonInput = JsonConvert.SerializeObject(scores);
            //  Skriver nya infon till sparfilen
            File.WriteAllText(Path, jsonInput);
        }
        /// <summary>
        /// Metod för att presentera HiScore meny
        /// </summary>
        /// <param name="pix">Player pix</param>
        public void HiScore(int pix)
        {
            var hiScoreMenu = true;
            var name = "";
            while (hiScoreMenu)
            {
                Console.Clear();
                Console.WriteLine($"Welcome to the HiScore list!\n" +
                $"Would you like to\n" +
                $"\t1 - View the list\n" +
                $"\t2 - Make an entry\n" +
                $"\t3 - Return to Menu");
                //  Switch som använder ReadKey
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        if (File.Exists(Path))
                        {
                            Console.Clear();
                            var hiScoreListan = GetScore();
                            foreach (var score in hiScoreListan)
                            {
                                Console.WriteLine("---------------------------");
                                Console.WriteLine($"|{score.Name}  {score.Pix}|");
                                Thread.Sleep(1000);
                            }
                            Console.ReadLine();
                        }
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        Console.WriteLine("Please enter your name:");
                        name = Console.ReadLine();
                        Program.jsonconfig.SaveScore(name, pix);
                        hiScoreMenu = false;
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        hiScoreMenu = false;
                        break;
                }
            }
        }
    }
    /// <summary>
    /// Score modell
    /// </summary>
    public class Score
    {
        public string Name { get; set; }
        public int Pix { get; set; }
    }
}