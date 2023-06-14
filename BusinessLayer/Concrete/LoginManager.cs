using BusinessLayer.Abstract;
using DataAccsesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LoginManager : ILoginService
    {
        IAdminDal _adminDal;
        IEmployerDal _employerDal;
        IJobSeekerDal _jobSeekerDal;

        public LoginManager(IAdminDal adminDal, IEmployerDal employerDal, IJobSeekerDal jobSeekerDal)
        {
            _adminDal = adminDal;
            _employerDal = employerDal;
            _jobSeekerDal = jobSeekerDal;
        }

        public Admin GetAdmin(string UserName, string Password)
        {
            return _adminDal.Get(x=>x.Username==UserName && x.Password==Password);
        }

        public Employer GetEmployer(string Email, string Password)
        {
            return _employerDal.Get(x => x.Email == Email && x.Password == Password);
        }

        public JobSeeker GetJobSeeker(string Email, string Password)
        {
            return _jobSeekerDal.Get(x => x.Email == Email && x.Password == Password);
        }
    }
}
