﻿using Grpc.Core;
using IntegrationAdapters.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Grpc
{
    public class NetGrpcServiceImpl : NetGrpcService.NetGrpcServiceBase
    {
        public override Task<MessageResponseProto> transfer(MessageProto request, ServerCallContext context)
        {
            Console.WriteLine(request.Message + " from spring; random int: " + request.RandomInteger.ToString());
            MessageResponseProto response = new MessageResponseProto();
            response.Response = "NET GRPC RESPONSE " + Guid.NewGuid().ToString();
            response.Status = "STATUS OK";
            return Task.FromResult(response);
        }
    }
}
