using Grpc.Net.Client;
using IntegrationAdapters.Protos;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:51492");
            var client = new NetGrpcService.NetGrpcServiceClient(channel);
            var requested = new MedicationRequest { Name = "Aspirin" };
            var reply = await client.transferAsync(requested);
            Console.WriteLine($"{reply.Message}");
            Console.ReadLine();
        }
    }
}
