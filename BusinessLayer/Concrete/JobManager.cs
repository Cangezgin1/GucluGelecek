using BusinessLayer.Abstract;
using DataAccsesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class JobManager:IJobService
    {
        IJobDal _jobDal;

        public JobManager(IJobDal jobDal)
        {
            _jobDal = jobDal;
        }

        public void Create(Job job)
        {
            _jobDal.Insert(job);    
        }

        public void Delete(Job job)
        {
            _jobDal.Delete(job);    
        }

        public List<Job> GetAll()
        {
            return _jobDal.List();    
        }

        public Job GetByEmployerId(int id)
        {
            return _jobDal.Get(x=>x.EmployerID==id);
        }

        public Job GetById(int id)
        {
            return _jobDal.Get(x=>x.JobID==id);
        }

        public void Update(Job job)
        {
            _jobDal.Update(job);    
        }
    }
}
