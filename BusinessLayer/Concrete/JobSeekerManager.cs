using BusinessLayer.Abstract;
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
        private readonly IJobSeekerService _jobSeekerService;

        public JobSeekerManager(IJobSeekerService jobSeekerService)
        {
            _jobSeekerService = jobSeekerService;
        }

        public void Create(JobSeeker jobSeeker)
        {
            _jobSeekerService.Create(jobSeeker);
        }

        public void Delete(JobSeeker jobSeeker)
        {
            _jobSeekerService.Delete(jobSeeker);
        }

        public List<JobSeeker> GetAll()
        {
            return _jobSeekerService.GetAll();
        }

        public JobSeeker GetById(int id)
        {
            return _jobSeekerService.GetById(id);   
        }

        public void Update(JobSeeker jobSeeker)
        {
            _jobSeekerService.Update(jobSeeker);
        }
    }
}
