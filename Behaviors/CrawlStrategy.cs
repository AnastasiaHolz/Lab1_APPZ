public class CrawlStrategy : IMoveStrategy
{
    public void Move(Animal animal, GameTime time)
    {
        if (!animal.IsAlive) return;

        time.AddHours(1);
    }
}