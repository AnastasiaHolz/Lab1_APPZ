using System;

abstract class Animal
{
    public string Name { get; set; }

    public int Legs { get; protected set; }
    public int Wings { get; protected set; }

    public bool IsAlive { get; protected set; } = true;
    public bool IsHappy { get; protected set; }

    public int MealsToday { get; protected set; }

    public DateTime LastMealTime { get; protected set; }
    public DateTime LastCleaningTime { get; protected set; }
    private DateTime LastDayCheck;

    protected Animal(string name, GameTime gameTime)
    {
        Name = name;
        GameTime = gameTime;

        LastMealTime = gameTime.CurrentTime;
        LastCleaningTime = gameTime.CurrentTime;
    }
    protected GameTime GameTime;

    public event Action<string>? Hungry;
    public event Action<string>? Died;
    public event Action<string>? BecameHappy;

    protected Animal(string name)
    {
        Name = name;
        LastMealTime = GameTime.CurrentTime;
        LastCleaningTime = GameTime.CurrentTime;
    }

    public void Eat()
{
    if (!IsAlive)
        return;

    if (MealsToday >= 5)
    {
        IsAlive = false;
        Died?.Invoke($"{Name} died: overeating limit exceeded (5 meals/day).");
        return;
    }

    MealsToday++;

    LastMealTime = GameTime.CurrentTime;
}

    public void Clean()
    {
        LastCleaningTime = GameTime.CurrentTime;

        if (!IsHappy)
        {
            IsHappy = true;
            BecameHappy?.Invoke($"{Name} is happy!");
        }
    }

    public void Walk()
    {
        if (!IsAlive)
            return;
    }

    public bool CanRunOrFly()
    {
        return (GameTime.CurrentTime - LastMealTime).TotalHours <= 8;
    }

    public void CheckState()
    {
        double hoursWithoutFood =
            (GameTime.CurrentTime - LastMealTime).TotalHours;

        if (hoursWithoutFood > 24)
        {
            IsAlive = false;
            Died?.Invoke($"{Name} died from hunger.");
        }
        else if (hoursWithoutFood > 8)
        {
            Hungry?.Invoke($"{Name} is hungry.");
        }

        IsHappy =
            (GameTime.CurrentTime - LastCleaningTime).TotalHours <= 24;

        if (GameTime.CurrentTime.Date > LastMealTime.Date)
        {
            MealsToday = 0;
        }
    }

    public string GetStatus()
    {
        string status =
    $@"Name: {Name}
    Alive: {IsAlive}
    Happy: {IsHappy}
    Meals today: {MealsToday}
    Last meal: {LastMealTime}
    Last cleaning: {LastCleaningTime}";

    if (GameTime.CurrentTime.Date > LastDayCheck.Date)
    {
        MealsToday = 0;
        LastDayCheck = GameTime.CurrentTime;
    }

        return status;
    }
}

