using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Interface
{
    public interface ITeacherRepository : IRepositoryBase<Teacher>
    {
        Task<IEnumerable<Teacher>> GetAllTeacherAsync();
        Task<Teacher> GetTeacherByIdAsync(int Id);
        Task<IEnumerable<Teacher>> GetTeacherByConditionAsync(Expression<Func<Teacher, bool>> predicate);
        void CreateTeacher(Teacher teacher);
        void UpdateTeacher(Teacher teacher);
        void RemoveTeacher(Teacher teacher);
    }
}