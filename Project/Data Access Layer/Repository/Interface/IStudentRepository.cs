using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Interface
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        Task<IEnumerable<Student>> GetAllStudentAsync();
        Task<Student> GetStudentByIdAsync(int Id);
        Task<IEnumerable<Student>> GetStudentByConditionAsync(Expression<Func<Student, bool>> predicate);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void RemoveStudent(Student student);
    }
}