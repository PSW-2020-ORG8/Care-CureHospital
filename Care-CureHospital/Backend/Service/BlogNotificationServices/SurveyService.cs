/***********************************************************************
 * Module:  SurveyService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.SurveyService
 ***********************************************************************/

using Model.Patient;
using Repository.BlogNotificationRepository;
using System;
using System.Collections.Generic;

namespace Service.BlogNotificationServices
{
    public class SurveyService : IService<Survey, int>
    {
        public ISurveyRepository surveyRepository;

        public SurveyService(ISurveyRepository surveyRepository)
        {
            this.surveyRepository = surveyRepository;
        }

        public Survey GetEntity(int id)
        {
            return surveyRepository.GetEntity(id);
        }

        public IEnumerable<Survey> GetAllEntities()
        {
            return surveyRepository.GetAllEntities();
        }

        public Survey AddEntity(Survey entity)
        {
            return surveyRepository.AddEntity(entity);
        }

        public void UpdateEntity(Survey entity)
        {
            surveyRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(Survey entity)
        {
            surveyRepository.DeleteEntity(entity);
        }

    }
}