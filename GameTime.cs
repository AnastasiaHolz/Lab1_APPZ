class GameTime
{
    public DateTime CurrentTime { get; private set; }

    public GameTime()
    {
        CurrentTime = DateTime.Now;
    }

    public void AddHours(int hours)
    {
        CurrentTime = CurrentTime.AddHours(hours);
    }

    public void AddMinutes(int minutes)
    {
        CurrentTime = CurrentTime.AddMinutes(minutes);
    }
}