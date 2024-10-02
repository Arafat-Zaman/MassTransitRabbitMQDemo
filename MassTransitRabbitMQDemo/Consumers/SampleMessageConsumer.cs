using MassTransit;
using MassTransitRabbitMQDemo.Messages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MassTransitRabbitMQDemo.Consumers
{
    public class SampleMessageConsumer : IConsumer<SampleMessage>
    {
        private readonly ILogger<SampleMessageConsumer> _logger;

        public SampleMessageConsumer(ILogger<SampleMessageConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<SampleMessage> context)
        {
            _logger.LogInformation("Received message: {Text} at {Timestamp}",
                context.Message.Text, context.Message.Timestamp);

            // Process the message here (e.g., save to database)
            return Task.CompletedTask;
        }
    }
}
