namespace Recipe.Users.Business.Interfaces
{
    public interface IKafkaProducer
    {
        Task ProduceAsync(string message);
    }
}