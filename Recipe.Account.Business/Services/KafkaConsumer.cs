using Confluent.Kafka;
using Microsoft.Extensions.Hosting;

namespace Recipe.Account.Business.Services
{
    public class KafkaConsumer: IHostedService
    {
        private readonly string _topic;
        private readonly IConsumer<Null, string> _consumer;

        public KafkaConsumer(string topic, string groupId, string bootstrapServers)
        {
            this._topic = topic;
            var config = new ConsumerConfig
            {
                GroupId = groupId,
                BootstrapServers = bootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            this._consumer = new ConsumerBuilder<Null, string>(config).Build();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(() => Consume(cancellationToken), cancellationToken);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this._consumer.Close();
            return Task.CompletedTask;
        }

        private void Consume(CancellationToken cancellationToken)
        {
            this._consumer.Subscribe(_topic);
            while (!cancellationToken.IsCancellationRequested)
            {
                var cr = this._consumer.Consume(cancellationToken);
                Console.WriteLine($"Consumed message '{cr.Value}' at: '{cr.TopicPartitionOffset}'.");
                // Handle the message (e.g., save to database, call another service, etc.)
            }
        }
    }
}
