using MassTransit;
using MassTransitRabbitMQDemo.Messages;
using Microsoft.AspNetCore.Mvc;

namespace MassTransitRabbitMQDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public MessageController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string text)
        {
            var message = new SampleMessage
            {
                Text = text,
                Timestamp = DateTime.Now
            };

            await _publishEndpoint.Publish(message);
            return Ok("Message Sent!");
        }
    }
}
