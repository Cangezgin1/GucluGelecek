using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IJobApplicationService
    {
        void Create(JobApplication jobApplication);
        void Delete(JobApplication jobApplication);
        void Update(JobApplication jobApplication);

        JobApplication GetById(int id);
        List<JobApplication> GetAll();
    }
}
