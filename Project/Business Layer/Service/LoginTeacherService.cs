using Business_Layer.ViewModels;
using Data_Access_Layer.Models;
using Data_Access_Layer.UnitOfWork;
using System.Linq;
using System.Threading.Tasks;

namespace Business_Layer.Service
{
    public class LoginTeacherService
    {
        public Teacher CurrentUser { get; set; }
        private UnitOfWork _unit;
        public LoginTeacherService() { }
        public LoginTeacherService(UnitOfWork unit) { _unit = unit; }

        public async Task<bool> AuthorizationAsync(AuthorizationViewModel model)
        {
            var user = (await _unit.Teacher.GetTeacherByConditionAsync(x => x.Login == model.Login && x.Password == model.Password)).FirstOrDefault();
            if (user != null)
            {
                CurrentUser = user;
                return true;
            }
            return false;
        }

        public async Task<bool> AddNewUserAsync(RegistrationViewModel model)
        {
            var user = (await _unit.Teacher.GetTeacherByConditionAsync(x => x.Login == model.Login)).FirstOrDefault();

            if (user == null)
            {
                _unit.Teacher.CreateTeacher(new Teacher()
                {
                    FullName = model.FullName,
                    Login = model.Login,
                    Password = model.Password,
                    Subject=model.Subject
                });

                CurrentUser = (await _unit.Teacher.GetTeacherByConditionAsync(x => x.Login == model.Login && x.Password == model.Password)).FirstOrDefault();
                return true;
            }
            return false;
        }
    }
}