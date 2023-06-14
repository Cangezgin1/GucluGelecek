using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class JobManager:IJobService
    {
        private readonly IJobService _jobService;

        public JobManager(IJobService jobService)
        {
            _jobService = jobService;
        }

        public void Create(Job job)
        {
            _jobService.Create(job);    
        }

        public void Delete(Job job)
        {
            _jobService.Delete(job);    
        }

        public List<Job> GetAll()
        {
            return _jobService.GetAll();    
        }

        public Job GetById(int id)
        {
            return _jobService.GetById(id);
        }

        public void Update(Job job)
        {
            _jobService.Update(job);    
        }
    }
}
