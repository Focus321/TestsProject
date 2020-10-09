using Data_Access_Layer.Repository.Interface;
using System.Threading.Tasks;

namespace Data_Access_Layer.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAnswerRepository Answer { get; }
        ICompletedRepository Completed { get; }
        IQuestionRepository Question { get; }
        IResultRepository Result { get; }
        IStudentRepository Student { get; }
        ITeacherRepository Teacher { get; }
        ITestRepository Test { get; }
        Task SaveAsync();
    }
}