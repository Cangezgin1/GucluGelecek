using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IEmployerService
    {
        void Create(Employer employer);
        void Delete(Employer employer);
        void Update(Employer employer);

        Employer GetById(int id);
        List<Employer> GetAll();
    }
}
