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
    public class ResultRepository : RepositoryBase<Result>, IResultRepository
    {
        public ResultRepository(TestingDB context) : base(context) { }
        public void CreateResult(Result result)
        {
            Create(result);
        }

        public async Task<IEnumerable<Result>> GetAllResultAsync()
        {
            return await FindAll()
                .Include(x=>x.Completed).ToListAsync();
        }

        public async Task<IEnumerable<Result>> GetResultByConditionAsync(Expression<Func<Result, bool>> predicate)
        {
            
            return await FindByCondition(predicate)
                .Include(x => x.Completed).ToListAsync();
        }

        public async Task<Result> GetResultByIdAsync(int Id)
        {
            return await FindByCondition(x => x.Id == Id)
                .Include(x => x.Completed).FirstOrDefaultAsync();
        }

        public void RemoveResult(Result result)
        {
            Delete(result);
        }

        public void UpdateResult(Result result)
        {
            Update(result);
        }
    }
}