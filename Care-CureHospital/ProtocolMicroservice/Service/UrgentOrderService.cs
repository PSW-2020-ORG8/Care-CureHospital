using ProtocolMicroservice.Domain;
using ProtocolMicroservice.Dto;
using ProtocolMicroservice.Repository;
using RestSharp;
using System;
using System.Collections.Generic;

namespace ProtocolMicroservice.Service
{
    public class UrgentOrderService : IUrgentOrderService
    {
        public IProtocolRepository protocolRepository;

        public UrgentOrderService(IProtocolRepository protocolRepository)
        {
            this.protocolRepository = protocolRepository;
        }

        public String SendRequestForOrder(UrgentMedicineOrder medicineOrder) 
        {
            var client = new RestClient("http://localhost:8080");
            var request = new RestRequest("/urgentOrder/forMedicament");
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { id =  medicineOrder.Id, name = medicineOrder.Name, quantity= medicineOrder.Quantity });
            var response = client.Post<UrgentMedicineOrder>(request);
            if(response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception($"Error occured while sending request. {response.Content}" +
                    $"{response.StatusDescription}");
            }
            var result = response.Content;
            return result;
        }

        public UrgentMedicineOrder AddEntity(UrgentMedicineOrder entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(UrgentMedicineOrder entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UrgentMedicineOrder> GetAllEntities()
        {
            return protocolRepository.GetAllEntities();
        }

        public UrgentMedicineOrder GetEntity(int id)
        {
            return protocolRepository.GetEntity(id);
        }

        public void UpdateEntity(UrgentMedicineOrder entity)
        {
            throw new NotImplementedException();
        }
    }
}