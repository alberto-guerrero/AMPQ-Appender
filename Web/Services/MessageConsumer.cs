using Common;
using MassTransit;
using System.Threading.Tasks;

namespace Web.Services
{
    public class MessageConsumer : IConsumer<LogEvent>
    {
        private readonly IEventDispatcher _eventDispatcher;

        public MessageConsumer(IEventDispatcher eventDispatcher) => _eventDispatcher = eventDispatcher;

        public Task Consume(ConsumeContext<LogEvent> context)
        {
            // LogEvent was received from RabbitMQ
            // Dispatch event to Web project subscribers
            _eventDispatcher.OnLogEventReceived(context.Message);
            return Task.CompletedTask;
        }
    }
}