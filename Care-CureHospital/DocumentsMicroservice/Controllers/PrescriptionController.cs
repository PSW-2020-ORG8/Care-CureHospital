﻿using DocumentsMicroservice.Domain;
using DocumentsMicroservice.Dto;
using DocumentsMicroservice.Gateway.Interface;
using DocumentsMicroservice.Mapper;
using DocumentsMicroservice.Service;
using EventSourcingMicroservice.Domain;
using EventSourcingMicroservice.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private IPrescriptionService prescriptionService;
        private IMedicalExaminationGateway medicalExaminationGateway;
        private IDomainEventService domainEventService;

        public PrescriptionController(IPrescriptionService prescriptionService, IMedicalExaminationGateway medicalExaminationGateway, IDomainEventService domainEventService) 
        {
            this.prescriptionService = prescriptionService;
            this.medicalExaminationGateway = medicalExaminationGateway;
            this.domainEventService = domainEventService;
        }

        [HttpGet]       // GET /api/prescription
        public IActionResult GetAllPrescriptions()
        {
            domainEventService.Save(new URLEvent("/api/prescription", "GET"));
            List<PrescriptionDto> result = new List<PrescriptionDto>();
            this.prescriptionService.GetAllEntities().ToList().ForEach(prescription => 
                result.Add(PrescriptionMapper.PrescriptionToPrescriptionDto(prescription, medicalExaminationGateway.GetMedicalExaminationById(prescription.MedicalExaminationId))));
            return Ok(result);
        }

        [HttpGet("getForPatient/{patientID}")]       // GET /api/prescription/getForPatient/{id}
        public IActionResult GetPrescriptionsForPatient(int patientID)
        {
            domainEventService.Save(new URLEvent("/api/prescription/getForPatient/" + patientID, "GET"));
            List<PrescriptionDto> prescriptionsForPatient = new List<PrescriptionDto>();
            this.prescriptionService.GetPrescriptionsForPatient(patientID).ToList().ForEach(prescription => 
                prescriptionsForPatient.Add(PrescriptionMapper.PrescriptionToPrescriptionDto(prescription, medicalExaminationGateway.GetMedicalExaminationById(prescription.MedicalExaminationId))));
            return Ok(prescriptionsForPatient);
        }

        [HttpGet("findPrescriptionsByDoctor")]       // GET /api/prescription/findPrescriptionsByDoctor
        public IActionResult FindPrescriptionsByDoctor([FromQuery(Name = "patientId")] int patientId, [FromQuery(Name = "doctor")] string doctor)
        {
            domainEventService.Save(new URLEvent("/api/prescription/findPrescriptionsByDoctor", "GET"));
            List<PrescriptionDto> result = new List<PrescriptionDto>();
            this.prescriptionService.FindPrescriptionsForDoctorParameter(patientId, doctor).ToList().ForEach(prescription => 
                result.Add(PrescriptionMapper.PrescriptionToPrescriptionDto(prescription, medicalExaminationGateway.GetMedicalExaminationById(prescription.MedicalExaminationId))));
            return Ok(result);
        }

        [HttpGet("findPrescriptionsByDate")]       // GET /api/prescription/findPrescriptionsByDate
        public IActionResult FindPrescriptionsByDate([FromQuery(Name = "patientId")] int patientId, [FromQuery(Name = "date")] string date)
        {
            domainEventService.Save(new URLEvent("/api/prescription/findPrescriptionsByDate", "GET"));
            List<PrescriptionDto> result = new List<PrescriptionDto>();
            this.prescriptionService.FindPrescriptionsForDateParameter(patientId, date).ToList().ForEach(prescription => 
                result.Add(PrescriptionMapper.PrescriptionToPrescriptionDto(prescription, medicalExaminationGateway.GetMedicalExaminationById(prescription.MedicalExaminationId))));
            return Ok(result);
        }

        [HttpGet("findPrescriptionsByComment")]       // GET /api/prescription/findPrescriptionsByComment
        public IActionResult FindPrescriptionsByComment([FromQuery(Name = "patientId")] int patientId, [FromQuery(Name = "comment")] string comment)
        {
            domainEventService.Save(new URLEvent("/api/prescription/findPrescriptionsByComment", "GET"));
            List<PrescriptionDto> result = new List<PrescriptionDto>();
            this.prescriptionService.FindPrescriptionsForCommentParameter(patientId, comment).ToList().ForEach(prescription => 
                result.Add(PrescriptionMapper.PrescriptionToPrescriptionDto(prescription, medicalExaminationGateway.GetMedicalExaminationById(prescription.MedicalExaminationId))));
            return Ok(result);
        }

        [HttpGet("findPrescriptionsByMedicaments")]       // GET /api/prescription/findPrescriptionsByMedicaments
        public IActionResult FindPrescriptionsByMedicaments([FromQuery(Name = "patientId")] int patientId, [FromQuery(Name = "medicaments")] string medicaments)
        {
            domainEventService.Save(new URLEvent("/api/prescription/findPrescriptionsByMedicaments", "GET"));
            List<PrescriptionDto> result = new List<PrescriptionDto>();
            this.prescriptionService.FindPrescriptionsForMedicamentsParameter(patientId, medicaments).ToList().ForEach(prescription => 
                result.Add(PrescriptionMapper.PrescriptionToPrescriptionDto(prescription, medicalExaminationGateway.GetMedicalExaminationById(prescription.MedicalExaminationId))));
            return Ok(result);
        }

        [HttpPost("advancedSearchPrescriptionsForPatient")]        // POST /api/prescription/advancedSearchPrescriptionsForPatient
        public IActionResult FindPrescriptionsForPatient(PrescriptionDto dto)
        {
            domainEventService.Save(new URLEvent("/api/prescription/advancedSearchPrescriptionsForPatient", "POST"));
            List<PrescriptionDto> result = new List<PrescriptionDto>();
            this.prescriptionService.FindPrescriptionsUsingAdvancedSearch(dto.PatientId, dto.SearchParams, dto.LogicOperators).ToList().ForEach(prescription => 
                result.Add(PrescriptionMapper.PrescriptionToPrescriptionDto(prescription, medicalExaminationGateway.GetMedicalExaminationById(prescription.MedicalExaminationId))));
            return Ok(result);
        }

        [HttpGet("simpleSearchPrescriptionForPatient")]       // GET /api/prescription/simpleSearchPrescriptionForPatient  
        public IActionResult FindPrescriptionsForPatientUsingSimpleSearch([FromQuery(Name = "patientId")] int patientId, [FromQuery(Name = "doctor")] string doctor, [FromQuery(Name = "date")] string date, [FromQuery(Name = "comment")] string comment, [FromQuery(Name = "medicaments")] string medicaments)
        {
            domainEventService.Save(new URLEvent("/api/prescription/simpleSearchPrescriptionForPatient ", "GET"));
            List<PrescriptionDto> result = new List<PrescriptionDto>();
            this.prescriptionService.FindPrescriptionsUsingSimpleSearch(patientId, doctor, date, comment, medicaments).ToList().ForEach(prescription => 
                result.Add(PrescriptionMapper.PrescriptionToPrescriptionDto(prescription, medicalExaminationGateway.GetMedicalExaminationById(prescription.MedicalExaminationId))));
            return Ok(result);
        }

        [HttpGet("getPrescriptionByMedicalExaminationId/{medicalExaminationId}")]       // GET /api/prescription/getPrescriptionByMedicalExaminationId/{medicalExaminationId}
        public IActionResult GetPrescriptionByMedicalExaminationId(int medicalExaminationId)
        {
            Prescription prescription = prescriptionService.GetPrescriptionByMedicalExaminationId(medicalExaminationId);
            if(prescription == null)
            {
                return NotFound();
            }
            return Ok(PrescriptionMapper.PrescriptionToPrescriptionDto(prescription, medicalExaminationGateway.GetMedicalExaminationById(prescription.MedicalExaminationId)));
        }
    }
}
