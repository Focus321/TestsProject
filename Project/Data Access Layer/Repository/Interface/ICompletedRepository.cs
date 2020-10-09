using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Text;


namespace Data_Access_Layer.Repository.Interface
{
    public interface ICompletedRepository: IRepositoryBase<Completed>
    {
        Task<IEnumerable<Completed>> GetAllCompletedAsync();
        Task<Completed> GetCompletedByIdAsync(int Id);
        Task<IEnumerable<Completed>> GetCompletedByConditionAsync(Expression<Func<Completed, bool>> predicate);
        void CreateCompleted(Completed completed);
        void UpdateCompleted(Completed completed);
        void RemoveCompleted(Completed completed);
    }
}