using Grpc.Core;
using IntegrationAdapters.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace IntegrationAdapters
{
    public class NetGrpcServiceImpl : NetGrpcService.NetGrpcServiceBase
    {
        public override Task<MedicationReply> transfer(MedicationRequest request, ServerCallContext context)
        {
            /*  Console.WriteLine(request.Message + "from spring; random int:" + request.RandomInteger.ToString());
              MessageResponseProto response = new MessageResponseProto();
              response.Response = "NET GRPC RESPONSE" + Guid.NewGuid().ToString();
              response.Status = "STATUS OK";*/

            MedicationReply output = new MedicationReply();

            if (request.Name == "Aspirin")
            {
                output.Message = "Confirmed";
            }
            else if(request.Name == "Analgin")
            {
                output.Message = "Not confirmed";
            }

            return Task.FromResult(output);
           /* return Task.FromResult(new MedicationReply

            {
                Message = "Hello" + request.Name
            });*/
        }
    }
}
