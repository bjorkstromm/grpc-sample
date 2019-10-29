using System;
using System.Threading.Tasks;
using Greeter;
using Greeter.DTO;
using Grpc.Core;
using Grpc.Net.Client;

namespace client.grpccore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // This switch must be set before creating the GrpcChannel/HttpClient.
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            var channel = GrpcChannel.ForAddress("http://localhost:50051");
            var client =  new GreeterService.GreeterServiceClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
