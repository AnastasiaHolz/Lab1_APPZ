public class Owner
{
    public string Name { get; set; }

    public Animal Pet { get; set; }

    public Owner(string name, Animal pet)
    {
        Name = name;
        Pet = pet;
    }

    public void FeedPet()
    {
        Pet.Eat();
    }

    public void CleanPet()
    {
        Pet.Clean();
    }
}