using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IJobService
    {
        void Create(Job job);
        void Delete(Job job);
        void Update(Job job);

        Job GetById(int id);
        List<Job> GetAll();
    }
}
