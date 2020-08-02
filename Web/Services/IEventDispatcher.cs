using Common;
using System;

namespace Web.Services
{
    public interface IEventDispatcher
    {
        Action<LogEvent> OnLogEventReceived { get; set; }
    }
}