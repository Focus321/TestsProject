using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Interface
{
    public interface IAnswerRepository : IRepositoryBase<Answer>
    {
        Task<IEnumerable<Answer>> GetAllAnswerAsync();
        Task<Answer> GetAnswerByIdAsync(int Id);
        Task<IEnumerable<Answer>> GetAnswerByConditionAsync(Expression<Func<Answer, bool>> predicate);
        void CreateAnswer(Answer answer);
        void UpdateAnswer(Answer answer);
        void RemoveAnswer(Answer answer);
    }
}