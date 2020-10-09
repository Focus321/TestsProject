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
    public class AnswerRepository : RepositoryBase<Answer>, IAnswerRepository
    {
        public AnswerRepository(TestingDB context) : base(context) { }
        public void CreateAnswer(Answer answer)
        {
            Create(answer);
        }

        public async Task<IEnumerable<Answer>> GetAllAnswerAsync()
        {
            return await FindAll()
                .Include(x => x.Question).ToListAsync();
        }

        public async Task<IEnumerable<Answer>> GetAnswerByConditionAsync(Expression<Func<Answer, bool>> predicate)
        {
            return await FindByCondition(predicate)
                .Include(x => x.Question).ToListAsync();
        }

        public async Task<Answer> GetAnswerByIdAsync(int Id)
        {
            return await FindByCondition(x => x.Id == Id).Include(x => x.Question).FirstOrDefaultAsync();
        }

        public void RemoveAnswer(Answer answer)
        {
            Delete(answer);
        }

        public void UpdateAnswer(Answer answer)
        {
            Update(answer);
        }
    }
}