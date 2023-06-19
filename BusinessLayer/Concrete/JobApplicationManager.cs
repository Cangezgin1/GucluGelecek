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
    public class JobApplicationManager : IJobApplicationService
    {
        IJobApplicationDal _jobApplicationDal;

        
        public JobApplicationManager(IJobApplicationDal jobApplicationDal)
        {
            _jobApplicationDal = jobApplicationDal;
        }

        public void Create(JobApplication jobApplication)
        {
            _jobApplicationDal.Insert(jobApplication);
        }

        public void Delete(JobApplication jobApplication)
        {
            _jobApplicationDal.Delete(jobApplication);
        }

        public List<JobApplication> GetAll()
        {
            return _jobApplicationDal.List(); 
        }

        public JobApplication GetById(int id)
        {
            return _jobApplicationDal.Get(x=>x.JobApplicationID==id);
        }

        public void Update(JobApplication jobApplication)
        {
            _jobApplicationDal.Update(jobApplication);
        }
    }
}
