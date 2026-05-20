public static class AnimalFactory
{
    public static Animal Create(string type, string name, GameTime time)
    {
        return type.ToLower() switch
        {
            "cat" => new Cat(name, time),
            "parrot" => new Parrot(name, time),
            "snake" => new Snake(name, time),
            _ => throw new Exception("Unknown animal")
        };
    }
}