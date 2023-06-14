using BusinessLayer.Abstract;
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
        private readonly IEmployerService _employerService;

        public EmployerManager(IEmployerService employerService)
        {
            _employerService = employerService;
        }

        public void Create(Employer employer)
        {
            _employerService.Create(employer);
        }

        public void Delete(Employer employer)
        {
            _employerService.Delete(employer);  
        }

        public List<Employer> GetAll()
        {
            return _employerService.GetAll();   
        }

        public Employer GetById(int id)
        {
            return _employerService.GetById(id);    
        }

        public void Update(Employer employer)
        {
            _employerService.Update(employer);  
        }
    }
}
