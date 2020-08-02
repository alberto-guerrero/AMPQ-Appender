using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestMessageProducer
{
    public class MockService
    {
        ILogger<MockService> _logger;

        public MockService(ILogger<MockService> logger) => _logger = logger;

        public void Start()
        {
            _logger.LogInformation("Starting Mock Service");

            var r = new Random();

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(r.Next(0, 3000));

                var level = (LogLevel)r.Next(0, 5);

                switch (level)
                {
                    case LogLevel.Trace:
                        _logger.LogTrace($"Mock Trace Message {i}");
                        break;
                    case LogLevel.Debug:
                        _logger.LogDebug($"Mock Debug Message {i}");
                        break;
                    case LogLevel.Information:
                        _logger.LogInformation($"Mock Info Message {i}");
                        break;
                    case LogLevel.Warning:
                        _logger.LogWarning($"Mock Warning Message {i}");
                        break;
                    case LogLevel.Error:
                        _logger.LogError(new Exception("Custom Error Here"), $"Mock Error Message {i}");
                        break;
                    case LogLevel.Critical:
                        _logger.LogCritical($"Critical {i}");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
