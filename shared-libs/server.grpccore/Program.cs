using System;
using System.Threading.Tasks;
using Greeter;
using Greeter.DTO;
using Grpc.Core;

namespace server.grpccore
{
    class GreeterImpl : GreeterService.GreeterServiceBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply { Message = "Hello " + request.Name });
        }
    }

    class Program
    {
        const int Port = 50051;

        static async Task Main(string[] args)
        {
            var server = new Server
            {
                Services = { GreeterService.BindService(new GreeterImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Greeter server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            await server.ShutdownAsync();
        }
    }
}
