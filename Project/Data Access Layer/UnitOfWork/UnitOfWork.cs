using Data_Access_Layer.Context;
using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Interface;
using System.Threading.Tasks;

namespace Data_Access_Layer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private TestingDB _context;
        private IAnswerRepository _answer;
        private ICompletedRepository _completed;
        private IQuestionRepository _question;
        private IResultRepository _result;
        private IStudentRepository _student;
        private ITeacherRepository _teacher;
        private ITestRepository _test;
        public UnitOfWork(TestingDB context) { _context = context; }

        public IAnswerRepository Answer
        {
            get
            {
                if (_answer == null)
                    _answer = new AnswerRepository(_context);
                return _answer;
            }
        }

        public ICompletedRepository Completed
        {
            get
            {
                if (_completed == null)
                    _completed = new CompletedRepository(_context);
                return _completed;
            }
        }

        public IQuestionRepository Question
        {
            get
            {
                if (_question == null)
                    _question = new QuestionRepository(_context);
                return _question;
            }
        }

        public IResultRepository Result
        {
            get
            {
                if (_result == null)
                    _result = new ResultRepository(_context);
                return _result;
            }
        }

        public IStudentRepository Student
        {
            get
            {
                if (_student == null)
                    _student = new StudentRepository(_context);
                return _student;
            }
        }

        public ITeacherRepository Teacher
        {
            get
            {
                if (_teacher == null)
                    _teacher = new TeacherRepository(_context);
                return _teacher;
            }
        }

        public ITestRepository Test
        {
            get
            {
                if (_test == null)
                    _test = new TestRepository(_context);
                return _test;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}