using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Interface
{
    public interface IResultRepository : IRepositoryBase<Result>
    {
        Task<IEnumerable<Result>> GetAllResultAsync();
        Task<Result> GetResultByIdAsync(int Id);
        Task<IEnumerable<Result>> GetResultByConditionAsync(Expression<Func<Result, bool>> predicate);
        void CreateResult(Result result);
        void UpdateResult(Result result);
        void RemoveResult(Result result);
    }
}