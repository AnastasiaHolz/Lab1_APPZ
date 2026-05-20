public class Parrot : Animal
{
    public Parrot(string name, GameTime gameTime)
        : base(name, gameTime)
    {
        Legs = 2;
        Wings = 2;
    }

    public void Fly()
    {
        if (!IsAlive)
            return;

        if (!CanRunOrFly())
            return;

        GameTime.AddHours(2);
    }

    public void Speak()
    {
        Console.WriteLine($"{Name} says: Chirp!");
    }
}