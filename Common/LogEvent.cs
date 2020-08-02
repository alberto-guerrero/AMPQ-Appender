using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class LogEvent
    {
        public DateTime Date { get; set; }

        public LogLevel LogLevel { get; set; }

        public EventId EventId { get; set; }

        public string Message { get; set; }
    }
}
