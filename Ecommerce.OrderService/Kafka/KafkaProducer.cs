using Confluent.Kafka;

namespace Ecommerce.OrderService.Kafka
{
    public interface IKafkaProducer
    {
        Task ProduceAsync(string topic,Message<string,string> message);
    }

    public class KafkaProducer : IKafkaProducer
    {
        private readonly IProducer<string, string> _producer;

        public KafkaProducer()
        {
            var config = new ConsumerConfig
            {
                GroupId = "order-group",
                BootstrapServers = "localhost:9892", //the address of kafka client
                AutoOffsetReset = AutoOffsetReset.Earliest,
            };

            _producer = new ProducerBuilder<string, string>(config).Build();
        }
        //
        public /*async */Task  ProduceAsync(string topic, Message<string, string> message)
        {
            return  /*await*/ _producer.ProduceAsync(topic,message);
        }
    }
}
