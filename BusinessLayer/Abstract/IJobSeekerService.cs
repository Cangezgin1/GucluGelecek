using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IJobSeekerService
    {
        void Create(JobSeeker jobSeeker);
        void Delete(JobSeeker jobSeeker);
        void Update(JobSeeker jobSeeker);

        JobSeeker GetById(int id);
        List<JobSeeker> GetAll();
    }
}
