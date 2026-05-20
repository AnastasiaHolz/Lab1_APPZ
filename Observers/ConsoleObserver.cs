public class ConsoleObserver : IAnimalObserver
{
    public void OnAnimalEvent(object sender, AnimalEventArgs e)
    {
        Console.WriteLine($"[{e.AnimalName}] {e.Message}");
    }
}