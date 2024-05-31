namespace Recipe.Users.Business.Interfaces
{
    public interface IProducerService
    {
        Task ProduceAsync(string topic, string message);
    }
}