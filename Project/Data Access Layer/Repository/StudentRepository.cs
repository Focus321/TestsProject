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
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(TestingDB context) : base(context) { }

        public void CreateStudent(Student student)
        {
            Create(student);
        }

        public async Task<IEnumerable<Student>> GetAllStudentAsync()
        {
            return await FindAll()
                .Include(x=>x.Completeds).ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudentByConditionAsync(Expression<Func<Student, bool>> predicate)
        {
            return await FindByCondition(predicate)
                .Include(x => x.Completeds).ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int Id)
        {
            return await FindByCondition(x => x.Id == Id)
                .Include(x => x.Completeds).FirstOrDefaultAsync();
        }

        public void RemoveStudent(Student student)
        {
            Delete(student);
        }

        public void UpdateStudent(Student student)
        {
            Update(student);
        }
    }
}