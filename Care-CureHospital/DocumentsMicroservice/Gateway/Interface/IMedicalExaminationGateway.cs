﻿using DocumentsMicroservice.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Gateway.Interface
{
    public interface IMedicalExaminationGateway
    {
        public MedicalExamination GetMedicalExaminationById(int id);
    }
}
