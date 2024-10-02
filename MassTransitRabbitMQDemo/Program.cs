using MassTransit;
using MassTransitRabbitMQDemo.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add MassTransit and RabbitMQ configuration
builder.Services.AddMassTransit(x =>
{
    // Add consumer
    x.AddConsumer<SampleMessageConsumer>();

    // Configure RabbitMQ as the transport
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        // Configure the endpoints
        cfg.ConfigureEndpoints(context);
    });
});

// Add MassTransit as a hosted service
builder.Services.AddMassTransitHostedService();

var app = builder.Build();

app.MapGet("/", () => "MassTransit with RabbitMQ Demo!");

app.Run();
