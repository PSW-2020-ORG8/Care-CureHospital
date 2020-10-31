// File:    ISurveyRepository.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 00:48:42
// Purpose: Definition of Interface ISurveyRepository

using Model.Patient;
using System;

namespace Repository.BlogNotificationRepository
{
    public interface ISurveyRepository : IRepository<Survey, int>
    {
    }
}