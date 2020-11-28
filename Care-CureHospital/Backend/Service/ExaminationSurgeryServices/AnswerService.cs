﻿using Backend.Repository.ExaminationSurgeryRepository;
using Model.Patient;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.ExaminationSurgeryServices
{
    public class AnswerService : IService<Answer, int>
    {
        public IAnswerRepository answerRepository;
        public QuestionService questionService;

        public AnswerService(IAnswerRepository answerRepository, QuestionService questionService)
        {
            this.answerRepository = answerRepository;
            this.questionService = questionService;
        }

        public Answer AddEntity(Answer entity)
        {
            return answerRepository.AddEntity(entity);
        }

        public void DeleteEntity(Answer entity)
        {
            answerRepository.DeleteEntity(entity);
        }

        public IEnumerable<Answer> GetAllEntities()
        {
            return answerRepository.GetAllEntities();
        }

        public Answer GetEntity(int id)
        {
            return answerRepository.GetEntity(id);
        }

        public void UpdateEntity(Answer entity)
        {
            answerRepository.UpdateEntity(entity);
        }

        public Dictionary<int, List<int>> GetAnswersByQuestion()
        {
            Dictionary<int, List<int>> results = new Dictionary<int, List<int>>();
            foreach (Answer answer in answerRepository.GetAllEntities())
            {
                if (!results.ContainsKey(answer.QuestionId))
                {
                    results.Add(answer.QuestionId, new List<int>() { 0, 0, 0, 0, 0 });
                }

                results[answer.QuestionId][(int)answer.Grade]++;
            }
            return results;
        }

        public Dictionary<int, List<int>> GetAnswersForDoctorBySurveyIds(List<int> surveyIds)
        {
            Dictionary<int, List<int>> results = new Dictionary<int, List<int>>();
            List<int> doctorTypeQuestionsIds = questionService.GetDoctorTypeQuestionsIds();
            foreach (Answer answer in answerRepository.GetAllEntities())
            {
                if (doctorTypeQuestionsIds.Contains(answer.QuestionId) && surveyIds.Contains(answer.SurveyId))
                {
                    if (!results.ContainsKey(answer.QuestionId))
                    {
                        results.Add(answer.QuestionId, new List<int>() { 0, 0, 0, 0, 0 });
                    }

                    results[answer.QuestionId][(int)answer.Grade]++;
                }
            }
            return results;
        }


    }
}