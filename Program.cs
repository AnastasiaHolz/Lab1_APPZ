using System;

class Program
{
    static void Main()
    {
        GameTime gameTime = new GameTime();

        Console.Write("Owner name: ");
        string ownerName = Console.ReadLine();

        Console.WriteLine("Choose animal: cat / parrot / snake");
        string type = Console.ReadLine();

        Console.Write("Pet name: ");
        string petName = Console.ReadLine();

        Animal pet = AnimalFactory.Create(type, petName, gameTime);
        Owner owner = new Owner(ownerName, pet);

        ConsoleObserver console = new ConsoleObserver();
        pet.AnimalEvent += console.OnAnimalEvent;

        Console.WriteLine("\nSimulation started...\n");

        bool exit = false;

        while (!exit && pet.IsAlive)
        {
            Console.WriteLine($"\nTime: {gameTime.CurrentTime}");
            Console.WriteLine($"Pet: {pet.Name} ({pet.GetType().Name})");

            Console.WriteLine("\n1 Feed");
            Console.WriteLine("2 Clean");
            Console.WriteLine("3 Walk");
            Console.WriteLine("4 Move (Run/Fly/Crawl)");
            Console.WriteLine("5 Talk");
            Console.WriteLine("6 Wait 3 hours");
            Console.WriteLine("7 Status");
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
                    ExecuteMovement(pet, gameTime);
                    break;

                case "5":
                    pet.Speak();
                    break;

                case "6":
                    gameTime.AddHours(3);
                    break;

                case "7":
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

    static void ExecuteMovement(Animal pet, GameTime gameTime)
    {
        IMoveStrategy strategy = pet.GetType().Name switch
        {
            "Cat" => new RunStrategy(),
            "Parrot" => new FlyStrategy(),
            "Snake" => new CrawlStrategy(),
            _ => null
        };

        strategy?.Move(pet, gameTime);
    }
}