using Common;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;

namespace TestMessageProducer
{
    public class Logger<T> : ILogger<T>, IDisposable
    {
        IBusControl _bus;

        public Logger()
        {
            _bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                // RabbitMQ Host & Credentials
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });

            _bus.Start();
        }

        public IDisposable BeginScope<TState>(TState state) => null;


        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exception);
            Console.WriteLine(message);
            _bus.Publish(new LogEvent
            {
                Date = DateTime.Now,
                EventId = eventId,
                LogLevel = logLevel,
                Message = message
            });
        }
        public void Dispose() => _bus?.Stop();
    }
}
