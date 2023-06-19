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
    public class EmployerManager : IEmployerService
    {
        IEmployerDal _employerDal;

       
        public EmployerManager(IEmployerDal employerDal)
        {
            _employerDal = employerDal;
        }

        public void Create(Employer employer)
        {
            _employerDal.Insert(employer);
        }

        public void Delete(Employer employer)
        {
            _employerDal.Delete(employer);  
        }

        public List<Employer> GetAll()
        {
            return _employerDal.List();   
        }

        public Employer GetById(int id)
        {
            return _employerDal.Get(x=>x.EmployerID==id);    
        }

        public void Update(Employer employer)
        {
            _employerDal.Update(employer);  
        }
    }
}
