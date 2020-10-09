using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Interface
{
    public interface ITestRepository : IRepositoryBase<Test>
    {
        Task<IEnumerable<Test>> GetAllTestAsync();
        Task<Test> GetTestByIdAsync(int Id);
        Task<IEnumerable<Test>> GetTestByConditionAsync(Expression<Func<Test, bool>> predicate);
        void CreateTest(Test test);
        void UpdateTest(Test test);
        void RemoveTest(Test test);
    }
}