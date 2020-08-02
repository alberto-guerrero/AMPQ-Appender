using Common;
using System;

namespace Web.Services
{
    public class EventDispatcher : IEventDispatcher
    {
        public Action<LogEvent> OnLogEventReceived { get; set; } = (e) => { };
    }
}
