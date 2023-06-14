using BusinessLayer.Abstract;
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
        private readonly IJobApplicationService _jobApplicationService;

        public JobApplicationManager(IJobApplicationService jobApplicationService)
        {
            _jobApplicationService = jobApplicationService;
        }

        public void Create(JobApplication jobApplication)
        {
            _jobApplicationService.Create(jobApplication);
        }

        public void Delete(JobApplication jobApplication)
        {
            _jobApplicationService.Delete(jobApplication);
        }

        public List<JobApplication> GetAll()
        {
            return _jobApplicationService.GetAll(); 
        }

        public JobApplication GetById(int id)
        {
            return _jobApplicationService.GetById(id);
        }

        public void Update(JobApplication jobApplication)
        {
            _jobApplicationService.Update(jobApplication);
        }
    }
}
