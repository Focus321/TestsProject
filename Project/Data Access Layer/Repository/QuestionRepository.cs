using Data_Access_Layer.Context;
using Data_Access_Layer.Models;
using Data_Access_Layer.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(TestingDB context) : base(context) { }

        public void CreateQuestion(Question question)
        {
            Create(question);
        }

        public async Task<IEnumerable<Question>> GetAllQuestionAsync()
        {
            return await FindAll()
                .Include(x=>x.Test)
                .Include(x => x.Answers).ToListAsync();
        }

        public async Task<IEnumerable<Question>> GetQuestionByConditionAsync(Expression<Func<Question, bool>> predicate)
        {
            return await FindByCondition(predicate)
                .Include(x => x.Test)
                .Include(x => x.Answers).ToListAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(int Id)
        {
            return await FindByCondition(x => x.Id == Id)
                .Include(x => x.Test)
                .Include(x => x.Answers).FirstOrDefaultAsync();
        }

        public void RemoveQuestion(Question question)
        {
            Delete(question);
        }

        public void UpdateQuestion(Question question)
        {
            Update(question);
        }
    }
}