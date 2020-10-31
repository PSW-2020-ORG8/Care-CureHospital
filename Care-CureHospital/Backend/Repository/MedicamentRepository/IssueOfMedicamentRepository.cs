/***********************************************************************
 * Module:  IssueMedicamentRepository.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Repository.IssueMedicamentRepository
 ***********************************************************************/

using Model.Doctor;
using Repository.Csv;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using Repository.IDSequencer;
using System;

namespace Repository.MedicamentRepository
{
    public class IssueOfMedicamentRepository : CSVRepository<IssueOfMedicaments, int>, IIssueOfMedicamentRepository
    {
        private const string ISSUEOFMEDICAMENTS_FILE = "../../Resources/Data/issueofmedicaments.csv";
        private static IssueOfMedicamentRepository instance;

        public static IssueOfMedicamentRepository Instance()
        {
            if (instance == null)
            {
                instance = new IssueOfMedicamentRepository(
               new CSVStream<IssueOfMedicaments>(ISSUEOFMEDICAMENTS_FILE, new IssueMedicamentCSVConverter(",")),
               new IntSequencer());
            }
            return instance;
        }

        public IssueOfMedicamentRepository(ICSVStream<IssueOfMedicaments> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }

    }
}