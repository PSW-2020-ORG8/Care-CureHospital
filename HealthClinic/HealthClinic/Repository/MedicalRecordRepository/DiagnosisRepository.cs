/***********************************************************************
 * Module:  DiagnosisRepository.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Repository.DiagnosisRepository
 ***********************************************************************/

using Model.PatientDoctor;
using Repository.Csv;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using Repository.IDSequencer;
using System;

namespace Repository.MedicalRecordRepository
{
    public class DiagnosisRepository : CSVRepository<Diagnosis, int>, IDiagnosisRepository
    {

        private const string DIAGNOSIS_FILE = "../../Resources/Data/diagnosis.csv";
        private static DiagnosisRepository instance;

        public static DiagnosisRepository Instance()
        {
            if (instance == null)
            {
                instance = new DiagnosisRepository(
                new CSVStream<Diagnosis>(DIAGNOSIS_FILE, new DiagnosisCSVConverter(",")),
                new IntSequencer());
            }
            return instance;
        }

        public DiagnosisRepository(ICSVStream<Diagnosis> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }

    }
}