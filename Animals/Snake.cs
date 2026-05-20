class Snake : Animal, ICrawlable, ISpeakable
{
    public Snake(string name, GameTime gameTime)
        : base(name, gameTime)
    {
        Legs = 0;
        Wings = 0;
    }

    public void Crawl()
    {
        if (!IsAlive)
            return;

        GameTime.AddHours(1);
    }

    public void Speak()
    {
        Console.WriteLine($"{Name} says: Ssssss!");
    }
}