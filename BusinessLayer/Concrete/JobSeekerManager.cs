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
    public class JobSeekerManager:IJobSeekerService
    {
        IJobSeekerDal _jobSeekerDal;

        
        public JobSeekerManager(IJobSeekerDal jobSeekerDal)
        {
            _jobSeekerDal = jobSeekerDal;
        }

        public void Create(JobSeeker jobSeeker)
        {
            _jobSeekerDal.Insert(jobSeeker);
        }

        public void Delete(JobSeeker jobSeeker)
        {
            _jobSeekerDal.Delete(jobSeeker);
        }

        public List<JobSeeker> GetAll()
        {
            return _jobSeekerDal.List();
        }

        public JobSeeker GetById(int id)
        {
            return _jobSeekerDal.Get(x=>x.JobSeekerID==id);   
        }

        public void Update(JobSeeker jobSeeker)
        {
            _jobSeekerDal.Update(jobSeeker);
        }
    }
}
