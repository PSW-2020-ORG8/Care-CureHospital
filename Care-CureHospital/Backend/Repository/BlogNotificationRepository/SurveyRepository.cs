/***********************************************************************
 * Module:  UserRepository.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Repository.UserRepository
 ***********************************************************************/

using Model.Patient;
using Repository.Csv;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using Repository.IDSequencer;
using System;

namespace Repository.BlogNotificationRepository
{
    public class SurveyRepository : CSVRepository<Survey, int>, ISurveyRepository
    {
        private const string SURVEY_FILE = "../../Resources/Data/surveys.csv";
        private static SurveyRepository instance;

        public static SurveyRepository Instance()
        {
            if (instance == null)
            {
                instance = new SurveyRepository(
                new CSVStream<Survey>(SURVEY_FILE, new SurveyCSVConverter(",")),
                new IntSequencer());
            }
            return instance;
        }

        public SurveyRepository(ICSVStream<Survey> stream, ISequencer<int> sequencer)
             : base(stream, sequencer)
        {
        }

    }
}