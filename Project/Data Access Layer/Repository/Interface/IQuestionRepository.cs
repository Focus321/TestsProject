using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Interface
{
    public interface IQuestionRepository : IRepositoryBase<Question>
    {
        Task<IEnumerable<Question>> GetAllQuestionAsync();
        Task<Question> GetQuestionByIdAsync(int Id);
        Task<IEnumerable<Question>> GetQuestionByConditionAsync(Expression<Func<Question, bool>> predicate);
        void CreateQuestion(Question question);
        void UpdateQuestion(Question question);
        void RemoveQuestion(Question question);
    }
}