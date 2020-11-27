using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPatient.Dto;

namespace WebAppPatient.Mapper
{
    public class QuestionResultMapper
    {
        public static List<QuestionResultDto> CreateQuestionResultsDto (Dictionary<int, List<int>> results)
        {
            List<QuestionResultDto> questionResults = new List<QuestionResultDto>();
            foreach (int key in results.Keys)
            {
                QuestionResultDto dto = new QuestionResultDto();

                dto.QuestionId = key;
                dto.Grades = new List<int>(results[key]);
                for (int i = 0; i < dto.Grades.Count; i++)
                {
                    dto.AverageGrade += dto.Grades[i] * (i + 1);
                }
                dto.AverageGrade = Math.Round(dto.AverageGrade / dto.Grades.Sum(), 2);

                questionResults.Add(dto);
            }

            return questionResults;
        }
    }
}
