﻿using FeedbackMicroservice.Domain;
using System.Collections.Generic;

namespace FeedbackMicroservice.Service
{
    public interface ISurveyService : IService<Survey, int>
    {
        public Dictionary<int, List<int>> GetSurveyIdsForDoctorIds();
        public Dictionary<int, Dictionary<int, List<int>>> GetSurveyResultsForAllDoctors();
    }
}
