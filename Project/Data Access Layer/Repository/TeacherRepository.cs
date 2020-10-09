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
    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(TestingDB context) : base(context) { }

        public void CreateTeacher(Teacher teacher)
        {
            Create(teacher);
        }

        public async Task<IEnumerable<Teacher>> GetAllTeacherAsync()
        {
            return await FindAll()
                .Include(x=>x.Tests).ToListAsync();
        }

        public async Task<IEnumerable<Teacher>> GetTeacherByConditionAsync(Expression<Func<Teacher, bool>> predicate)
        {
            return await FindByCondition(predicate)
                .Include(x => x.Tests).ToListAsync();
        }

        public async Task<Teacher> GetTeacherByIdAsync(int Id)
        {
            return await FindByCondition(x => x.Id == Id)
                .Include(x => x.Tests).FirstOrDefaultAsync();
        }

        public void RemoveTeacher(Teacher teacher)
        {
            Delete(teacher);
        }

        public void UpdateTeacher(Teacher teacher)
        {
            Update(teacher);
        }
    }
}