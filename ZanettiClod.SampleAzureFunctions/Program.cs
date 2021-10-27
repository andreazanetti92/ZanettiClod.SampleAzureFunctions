using Microsoft.Extensions.Hosting;

namespace ZanettiClod.SampleAzureFunctions
{
    public class Program
    {
        public static void Main()
        {

            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .Build();
            host.Run();
        }
    }
}