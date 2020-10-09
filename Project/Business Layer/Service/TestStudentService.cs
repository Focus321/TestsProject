using Business_Layer.ViewModels;
using Data_Access_Layer.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business_Layer.Service
{
    public class TestStudentService
    {
        private UnitOfWork _unit;
        public TestStudentService() { }
        public TestStudentService(UnitOfWork unit) { _unit = unit; }

        public async Task<List<TestViewModel>> GetListTests(int idStudent)
        {
            var student = await _unit.Student.GetStudentByIdAsync(idStudent);

            List<TestViewModel> tests = new List<TestViewModel>();

            foreach (var item in student.Completeds)
            {
                List<QuestionViewModel> questions = new List<QuestionViewModel>();
                var ress = await _unit.Test.GetTestByIdAsync(item.TestId);

                foreach (var item2 in ress.Questions)
                {
                    var answers = await _unit.Answer.GetAnswerByConditionAsync(x => x.QuestionId == item2.Id);
                    List<AnswerViewModel> answer = new List<AnswerViewModel>();
                    foreach (var item3 in answers)
                    {
                        answer.Add(new AnswerViewModel()
                        {
                            Id=item3.Id,
                            ResponseText = item3.ResponseText,
                            Right = item3.Right
                        });
                    }
                    questions.Add(new QuestionViewModel()
                    {
                        Id=item2.Id,
                        QuestionText = item2.QuestionText,
                        Appraisal = item2.Appraisal,
                        ImagePath = item2.ImagePath,
                        Answers = answer
                    });
                }
                tests.Add(new TestViewModel()
                {
                    Id=ress.Id,
                    ImagePath = ress.ImagePath,
                    TestName = ress.TestName,
                    NumberOfAttempts = ress.NumberOfAttempts,
                    Questions = questions,
                    Teacher= new TeacherViewModel()
                    {
                        FullName= ress.Teacher.FullName,
                        Subject=ress.Teacher.Subject
                    }
                });
            }
            return tests;
        }

        public async Task<TestViewModel> GeTestAsync(int idTest)
        {
            TestViewModel test = new TestViewModel();
            var res = await _unit.Test.GetTestByIdAsync(idTest);

            foreach (var item in res.Completeds)
            {
                List<QuestionViewModel> questions = new List<QuestionViewModel>();
                var ress = await _unit.Test.GetTestByIdAsync(item.TestId);

                foreach (var item2 in ress.Questions)
                {
                    var answers = await _unit.Answer.GetAnswerByConditionAsync(x => x.QuestionId == item2.Id);
                    List<AnswerViewModel> answer = new List<AnswerViewModel>();
                    foreach (var item3 in answers)
                    {
                        answer.Add(new AnswerViewModel()
                        {
                            Id=item3.Id,
                            ResponseText = item3.ResponseText,
                            Right = item3.Right
                        });
                    }
                    questions.Add(new QuestionViewModel()
                    {
                        Id=item2.Id,
                        QuestionText = item2.QuestionText,
                        Appraisal = item2.Appraisal,
                        ImagePath = item2.ImagePath,
                        Answers = answer
                    });
                }

                test.Id = ress.Id;
                test.ImagePath = ress.ImagePath;
                test.TestName = ress.TestName;
                test.NumberOfAttempts = ress.NumberOfAttempts;
                test.Questions = questions;
                test.Teacher = new TeacherViewModel()
                {
                    FullName = ress.Teacher.FullName,
                    Subject = ress.Teacher.Subject
                };

            }
            return test;
        }
    }
}