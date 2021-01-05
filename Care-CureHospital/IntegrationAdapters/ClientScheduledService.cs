﻿using Grpc.Core;
using IntegrationAdapters.Protos;
using System;
using System.Threading.Tasks;

namespace IntegrationAdapters
{
    public class ClientScheduledService //: IHostedService
    {
        private Channel channel;
        private SpringGrpcService.SpringGrpcServiceClient client;

        public ClientScheduledService() { }
        public async Task<string> SendMessage(string name)
        {
            channel = new Channel("127.0.0.1:8787", ChannelCredentials.Insecure);
            client = new SpringGrpcService.SpringGrpcServiceClient(channel);
            MessageResponseProto response = await client.communicateAsync(new MessageProto() { Message = name });
            Console.WriteLine("Response");
            Console.WriteLine(response.Response + " is response; status: " + response.Status);
            return response.Response;
        }
    }
}
