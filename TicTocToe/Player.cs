public class Player
{
    private string name;
    private int score;
    public string Name { 
        get { return name; }
        set { name = value; }
    }
    public int Score
    {
        get { return score; }
        set { score = value; }
    }
    public Player(string name)
    {
        Name = name;
        Score = 0;
    }
}