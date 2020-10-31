/***********************************************************************
 * Module:  SymptomsRepository.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Repository.SymptomsRepository
 ***********************************************************************/

using Model.PatientDoctor;
using Repository.Csv;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using Repository.IDSequencer;
using System;

namespace Repository.MedicalRecordRepository
{
    public class SymptomsRepository : CSVRepository<Symptoms, int>, ISymptomsRepository
    {

        private const string SYMPTOMS_FILE = "../../Resources/Data/symptoms.csv";
        private static SymptomsRepository instance;

        public static SymptomsRepository Instance()
        {
            if (instance == null)
            {
                instance = new SymptomsRepository(
               new CSVStream<Symptoms>(SYMPTOMS_FILE, new SymptomsCSVConverter(",")),
               new IntSequencer());
            }
            return instance;
        }

        public SymptomsRepository(ICSVStream<Symptoms> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }

    }
}