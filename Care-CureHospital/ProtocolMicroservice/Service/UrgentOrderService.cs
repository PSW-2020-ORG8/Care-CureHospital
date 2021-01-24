using ProtocolMicroservice.Domain;
using ProtocolMicroservice.Repository;
using RestSharp;
using System;
using System.Collections.Generic;

namespace ProtocolMicroservice.Service
{
    public class UrgentOrderService : IUrgentOrderService
    {
        public ISftpService sftpService;
        public IProtocolRepository protocolRepository;

        public UrgentOrderService(IProtocolRepository protocolRepository)
        {
            this.protocolRepository = protocolRepository;
        }

        public UrgentOrderService(IProtocolRepository protocolRepository, ISftpService sftpService)
        {
            this.sftpService = sftpService;
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

        public void SendRequestForOrderSftp(UrgentMedicineOrder medicineOrder)
        {
            String orderFile = "Files\\UrgentOrder_" + DateTime.Now.ToString("dd-MM-yyyy") + ".json";
            System.IO.File.WriteAllText(orderFile, enterOrder(medicineOrder));
            try
            {
                sftpService.UploadFile(orderFile);
            }
            catch (Exception e)
            {
                throw new Exception("The file can not be uploaded, because there where errors on the server side. Please try again later!", e);
            }
        }

        public String enterOrder(UrgentMedicineOrder medicineOrder)
        {
            return "Urgent order: \n\n" + "Medicament id: " + medicineOrder.Id +  "\nMedicament name: " + medicineOrder.Name + "\nQuantity: " + medicineOrder.Quantity;
        }
    }
}