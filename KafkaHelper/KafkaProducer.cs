﻿using Confluent.Kafka;
namespace KafkaHelper;


public class KafkaProducer
{
    private readonly string _topic;
    private readonly IProducer<Null, string> _producer;

    public KafkaProducer(string topic, string bootstrapServers)
    {
        _topic = topic;
        var config = new ProducerConfig { BootstrapServers = bootstrapServers };
        _producer = new ProducerBuilder<Null, string>(config).Build();
    }

    public async Task ProduceAsync(string message)
    {
        await _producer.ProduceAsync(_topic, new Message<Null, string> { Value = message });
    }
}

}
