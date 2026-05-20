public class Cat : Animal
{
    public Cat(string name, GameTime gameTime)
        : base(name, gameTime)
    {
        Legs = 4;
        Wings = 0;
    }

    public void Run()
    {
        if (!IsAlive)
            return;

        if (!CanRunOrFly())
            return;

        GameTime.AddHours(2);
    }

    public void Speak()
    {
    }
}