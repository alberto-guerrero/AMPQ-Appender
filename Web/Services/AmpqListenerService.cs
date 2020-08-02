using MassTransit;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Services
{
    public class AmpqListenerService : IHostedService
    {
        IBusControl _bus;

        public AmpqListenerService(IBusControl bus) => _bus = bus;

        public async Task StartAsync(CancellationToken cancellationToken) => await _bus.StartAsync();

        public async Task StopAsync(CancellationToken cancellationToken) => await _bus?.StopAsync();
    }
}