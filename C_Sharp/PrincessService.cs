using Microsoft.Extensions.Hosting;

namespace C_Sharp
{
    internal class PrincessService : IHostedService
    {
        private readonly Princess _princess;
        public PrincessService(Princess princess)
        {
            _princess = princess;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(RunAsync, cancellationToken);
            return Task.CompletedTask;
        }

        public void RunAsync()
        {
            _princess.FindHusband();
            _princess.PrintResult();
        }

            public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
