using System;
using System.Threading.Tasks;
using Greeter;
using Greeter.DTO;
using Grpc.Core;

namespace client.grpccore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = new Channel("localhost:50051", ChannelCredentials.Insecure);

            var client = new GreeterService.GreeterServiceClient(channel);
            var user = "h4xx0r";

            var reply = await client.SayHelloAsync(new HelloRequest { Name = user });
            Console.WriteLine("Greeting: " + reply.Message);

            await channel.ShutdownAsync();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
