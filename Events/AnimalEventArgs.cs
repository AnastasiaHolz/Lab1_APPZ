public class AnimalEventArgs : EventArgs
{
    public string AnimalName { get; }
    public string Message { get; }

    public AnimalEventArgs(string animalName, string message)
    {
        AnimalName = animalName;
        Message = message;
    }
}