using System;

class Program
{
    static void Main()
    {
        GameTime gameTime = new GameTime();

        Console.Write("Enter owner name: ");
        string ownerName = Console.ReadLine();

        Console.WriteLine("\nChoose animal:");
        Console.WriteLine("1 - Cat");
        Console.WriteLine("2 - Parrot");
        Console.WriteLine("3 - Snake");

        string choice = Console.ReadLine();

        Console.Write("Enter pet name: ");
        string petName = Console.ReadLine();

        Animal pet;

        switch (choice)
        {
            case "1":
                pet = new Cat(petName, gameTime);
                break;

            case "2":
                pet = new Parrot(petName, gameTime);
                break;

            case "3":
                pet = new Snake(petName, gameTime);
                break;

            default:
                Console.WriteLine("Invalid choice, default Cat created.");
                pet = new Cat(petName, gameTime);
                break;
        }

        Owner owner = new Owner(ownerName, pet);

        pet.Hungry += msg => Console.WriteLine("[HUNGRY] " + msg);
        pet.Died += msg => Console.WriteLine("[DEAD] " + msg);
        pet.BecameHappy += msg => Console.WriteLine("[HAPPY] " + msg);

        Console.WriteLine("\n--- Simulation started ---");

        bool exit = false;

        while (!exit && pet.IsAlive)
        {
            Console.WriteLine($"\nTime: {gameTime.CurrentTime}");
            Console.WriteLine($"Pet: {pet.Name} ({pet.GetType().Name})");

            Console.WriteLine("\n1 Feed");
            Console.WriteLine("2 Clean");
            Console.WriteLine("3 Walk");
            Console.WriteLine("4 Run");
            Console.WriteLine("5 Fly/Crawl (type dependent)");
            Console.WriteLine("6 Talk");
            Console.WriteLine("7 Wait 3 hours");
            Console.WriteLine("8 Status");
            Console.WriteLine("0 Exit");

            string action = Console.ReadLine();

            switch (action)
            {
                case "1":
                    owner.FeedPet();
                    gameTime.AddMinutes(30);
                    break;

                case "2":
                    owner.CleanPet();
                    gameTime.AddMinutes(20);
                    break;

                case "3":
                    pet.Walk();
                    gameTime.AddHours(1);
                    break;

                case "4":
                    if (pet is IRunnable r) r.Run();
                    gameTime.AddHours(2);
                    break;

                case "5":
                    if (pet is IFlyable f) f.Fly();
                    if (pet is ICrawlable c) c.Crawl();
                    gameTime.AddHours(2);
                    break;

                case "6":
                    if (pet is ISpeakable s) s.Speak();
                    break;

                case "7":
                    gameTime.AddHours(3);
                    break;

                case "8":
                    Console.WriteLine(pet.GetStatus());
                    break;

                case "0":
                    exit = true;
                    break;
            }

            pet.CheckState();
        }

        Console.WriteLine("\nSimulation ended.");
    }
}