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

        public String SendRequestForOrder(UrgentMedicineOrder medicineOrder) //sklonila static
        {
            var client = new RestClient("http://localhost:8080");
            var request = new RestRequest("/urgentOrder/forMedicament");
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddParameter("medicine", medicineOrder.Name);
            request.AddParameter("quantity", medicineOrder.Quantity);
            request.RequestFormat = DataFormat.Json;
            var response = client.Post<UrgentMedicineOrderDto>(request);
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