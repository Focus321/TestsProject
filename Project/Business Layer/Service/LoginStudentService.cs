using Business_Layer.ViewModels;
using Data_Access_Layer.Models;
using Data_Access_Layer.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business_Layer.Service
{
    public class LoginStudentService
    {
        public Student CurrentUser { get; set; }
        private UnitOfWork _unit;
        public LoginStudentService() { }
        public LoginStudentService(UnitOfWork unit) { _unit = unit; }

        public async Task<bool> AuthorizationAsync(AuthorizationViewModel model)
        {
            var user = (await _unit.Student.GetStudentByConditionAsync(x => x.Login == model.Login && x.Password == model.Password)).FirstOrDefault();
            if (user != null)
            {
                CurrentUser = user;
                return true;
            }
            return false;
        }

        public async Task<bool> AddNewUserAsync(RegistrationViewModel model)
        {
            var user = (await _unit.Student.GetStudentByConditionAsync(x => x.Login == model.Login)).FirstOrDefault();

            if (user == null)
            {
                _unit.Student.CreateStudent(new Student()
                {
                    FullName = model.FullName,
                    Login = model.Login,
                    Password = model.Password,
                });
                CurrentUser = (await _unit.Student.GetStudentByConditionAsync(x => x.Login == model.Login && x.Password == model.Password)).FirstOrDefault();
                await AddNewCompletedAsync();
                return true;
            }
            return false;
        }

        private async Task AddNewCompletedAsync()
        {
            List<Completed> completed = new List<Completed>();
            var tests = (await _unit.Test.GetAllTestAsync());

            foreach (var item in tests)
            {
                _unit.Completed.CreateCompleted(new Completed()
                {
                    StudentId = CurrentUser.Id,
                    TestId = item.Id
                });
            }
            CurrentUser = (await _unit.Student.GetStudentByConditionAsync(x => x.Login == CurrentUser.Login && x.Password == CurrentUser.Password)).FirstOrDefault();
        }
    }
}