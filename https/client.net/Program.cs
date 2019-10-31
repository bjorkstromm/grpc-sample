using System;
using System.Threading.Tasks;
using Greeter.Net;
using Grpc.Core;
using Grpc.Net.Client;

namespace client.grpccore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:50051");
            var client =  new Greeter.Net.Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "gRPC dotnet" });
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
