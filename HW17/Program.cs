using System.Collections;

try
{
    int players_count;
    Console.Write("Enter count of players (only numbers 2, 3, 4, 6, 9, 12, 18, 36): "); players_count = int.Parse(Console.ReadLine());
    Console.Clear();

    if (players_count == 2 || players_count == 3 || players_count == 4 || players_count == 6 || players_count == 9 || players_count == 12 || players_count == 18 || players_count == 36)
    {
        Game game = new Game(players_count);
        game.DoGame();
    }
    else throw new Exception("Error: Invalid value");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


class Game
{
    private List<Card> MainDeck;
    private List<Player> Players;
    private Random random;

    public Game(int players_count = 2)
    {
        MainDeck = new();
        Players = new();
        random = new();

        MainDeck.AddRange(new Card[]
            {
                new(6, "Spades", "Six"),
                new(7, "Spades", "Seven"),
                new(8, "Spades", "Eight"),
                new(9, "Spades", "Nine"),
                new(10, "Spades", "Ten"),
                new(11, "Spades", "Jack"),
                new(12, "Spades", "Queen"),
                new(13, "Spades", "King"),
                new(14, "Spades", "Ace"),

                new(6, "Clubs", "Six"),
                new(7, "Clubs", "Seven"),
                new(8, "Clubs", "Eight"),
                new(9, "Clubs", "Nine"),
                new(10, "Clubs", "Ten"),
                new(11, "Clubs", "Jack"),
                new(12, "Clubs", "Queen"),
                new(13, "Clubs", "King"),
                new(14, "Clubs", "Ace"),

                new(6, "Diamonds", "Six"),
                new(7, "Diamonds", "Seven"),
                new(8, "Diamonds", "Eight"),
                new(9, "Diamonds", "Nine"),
                new(10, "Diamonds", "Ten"),
                new(11, "Diamonds", "Jack"),
                new(12, "Diamonds", "Queen"),
                new(13, "Diamonds", "King"),
                new(14, "Diamonds", "Ace"),

                new(6, "Hearts", "Six"),
                new(7, "Hearts", "Seven"),
                new(8, "Hearts", "Eight"),
                new(9, "Hearts", "Nine"),
                new(10, "Hearts", "Ten"),
                new(11, "Hearts", "Jack"),
                new(12, "Hearts", "Queen"),
                new(13, "Hearts", "King"),
                new(14, "Hearts", "Ace")    });

        for (int i = MainDeck.Count - 1; i >= 1; i--)
        {
            int j = random.Next(i + 1);
            var temp = MainDeck[j];
            MainDeck[j] = MainDeck[i];
            MainDeck[i] = temp;
        }

        for (int i = 0; i < players_count; i++) Players.Add(new Player());

        int ind = 0;
        for (int i = 0; i < MainDeck.Count; i++)
        {
            Players[ind].Deck.Add(MainDeck[i]);
            ind++;
            ind %= Players.Count();
        }
    }

    public void DoGame()
    {
        while (true)
        {
            Console.WriteLine("Player\tCards Left\tCurrent Card");

            int MaxCardNominal = -1;
            Player Winner = null;
            LinkedList<Card> table = new();

            Console.Clear();
            for (int i = 0; i < Players.Count; i++)
            {
                Player tmp_player = Players[i];

                if (tmp_player.Deck.Count > 0)
                {
                    Card current_card = tmp_player.Deck[random.Next(tmp_player.Deck.Count)];

                    Console.WriteLine($"#{ i + 1 }\t{ tmp_player.Deck.Count }\t\t{ current_card }");
                    tmp_player.Deck.Remove(current_card);

                    if (current_card.Nominal > MaxCardNominal)
                    {
                        MaxCardNominal = current_card.Nominal;
                        Winner = tmp_player;
                    }

                    table.AddFirst(current_card);
                }
            }

            Winner?.Deck.AddRange(table);

            Console.WriteLine($"Player #{ (Players.IndexOf(Winner) + 1) } Took Cards");
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Console.WriteLine();

            if (Winner.Deck.Count == MainDeck.Count)
            {
                Console.WriteLine($"Player #{ (Players.IndexOf(Winner) + 1) } Won !");
                break;
            }
        }
    }
}

class Player
{
    public List<Card> Deck = new();
}

class Card
{
    public int Nominal { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }

    public Card(int nominal, string name, string type)
    {
        Nominal = nominal;
        Name = name;
        Type = type;
    }

    public override string ToString() => $"{Name,-8} - {Type,-8}";
}