using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.DoctorMenager;
using IntegrationAdapters.Dto;

namespace IntegrationAdapters.Mapper
{
    public class ReportMapper
    {
        public static Medicament ReportDtoToReport(ReportDto dto)
        {
            Medicament medicament = new Medicament();

            return medicament;
        }
    }
}
