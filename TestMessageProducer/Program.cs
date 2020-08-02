using System;

namespace TestMessageProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            using var logger = new Logger<MockService>();
            var mockService = new MockService(logger);
            mockService.Start();
        }
    }
}