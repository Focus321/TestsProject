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
    public class CompletedRepository : RepositoryBase<Completed>, ICompletedRepository
    {
        public CompletedRepository(TestingDB context) : base(context) { }
        public void CreateCompleted(Completed completed)
        {
            Create(completed);
        }

        public async Task<IEnumerable<Completed>> GetAllCompletedAsync()
        {
            return await FindAll()
                .Include(x=>x.Student)
                .Include(x => x.Test)
                .Include(x => x.Results).ToListAsync();
        }

        public async Task<IEnumerable<Completed>> GetCompletedByConditionAsync(Expression<Func<Completed, bool>> predicate)
        {
            return await FindByCondition(predicate)
                .Include(x => x.Student)
                .Include(x => x.Test)
                .Include(x => x.Results).ToListAsync();
        }

        public async Task<Completed> GetCompletedByIdAsync(int Id)
        {
            return await FindByCondition(x => x.Id == Id)
                .Include(x => x.Student)
                .Include(x => x.Test)
                .Include(x => x.Results).FirstOrDefaultAsync();
        }

        public void RemoveCompleted(Completed completed)
        {
            Delete(completed);
        }

        public void UpdateCompleted(Completed completed)
        {
            Update(completed);
        }
    }
}