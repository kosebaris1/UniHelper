using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.QuestionInterface
{
    public interface IQuestionRepository
    {
        //Task<List<Question>> GetAllQuestionByUniversity(int uniId);
        //Task<List<Question>> GetAllQuestionByUniversityAndDepartment(int uniId,int depId);
        //Task<List<Question>> GetAllQuestionByCity(int cityId);
        //Task<List<Question>> GetAllQuestionByTagId(int tagId);
        Task<List<Question>> GetFilteredQuestions(int? cityId, int? universityId, int? departmentId, List<int>? tagsId, string sortBy);
        Task<int> CreateQuestionAsync(Question question, List<int> tagIds);
        Task<Question> GetQuestionWithDetailsByIdAsync(int id);
        Task<List<Question>> GetTopQuestionAsync(int userId, int count);


    }
}
