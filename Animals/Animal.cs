using System;

public abstract class Animal
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
    public event EventHandler<AnimalEventArgs> AnimalEvent;


    protected void RaiseEvent(string message)
    {
        AnimalEvent?.Invoke(this,
            new AnimalEventArgs(Name, message));
    }
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

        MealsToday++;

        if (MealsToday > 5)
        {
            IsAlive = false;
            RaiseEvent("died from overeating");
            return;
        }

        LastMealTime = GameTime.CurrentTime;

        RaiseEvent("has eaten");
    }

    public void Clean()
    {
        LastCleaningTime = GameTime.CurrentTime;
        IsHappy = true;

        RaiseEvent("has been cleaned and is happy");
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

        if (hoursWithoutFood > 8)
        {
            RaiseEvent("is hungry");
        }

        if (hoursWithoutFood > 24)
        {
            IsAlive = false;
            RaiseEvent("died from starvation");
            return;
        }

        double hoursWithoutClean =
            (GameTime.CurrentTime - LastCleaningTime).TotalHours;

        if (hoursWithoutClean <= 24)
        {
            IsHappy = true;
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

    public virtual void Speak()
    {
        RaiseEvent($"{Name} makes a sound");
    }
}

