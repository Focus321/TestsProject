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
    public class TestRepository : RepositoryBase<Test>, ITestRepository
    {
        public TestRepository(TestingDB context) : base(context) { }

        public void CreateTest(Test test)
        {
            Create(test);
        }

        public async Task<IEnumerable<Test>> GetAllTestAsync()
        {
            return await FindAll()
                .Include(x=>x.Teacher)
                .Include(x=>x.Questions)
                .Include(x=>x.Completeds).ToListAsync();
        }

        public async Task<IEnumerable<Test>> GetTestByConditionAsync(Expression<Func<Test, bool>> predicate)
        {
            return await FindByCondition(predicate)
                .Include(x => x.Teacher)
                .Include(x => x.Questions)
                .Include(x => x.Completeds).ToListAsync();
        }

        public async Task<Test> GetTestByIdAsync(int Id)
        {
            return await FindByCondition(x => x.Id == Id)
                .Include(x => x.Teacher)
                .Include(x => x.Questions)
                .Include(x => x.Completeds).FirstOrDefaultAsync();
        }

        public void RemoveTest(Test test)
        {
            Delete(test);
        }

        public void UpdateTest(Test test)
        {
            Update(test);
        }
    }
}