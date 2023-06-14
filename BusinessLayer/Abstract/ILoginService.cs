using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ILoginService
    {

        Admin GetAdmin(string UserName, string Password);

        Employer GetEmployer(string Email, string Password);

        JobSeeker GetJobSeeker(string Email, string Password);

    }
}
