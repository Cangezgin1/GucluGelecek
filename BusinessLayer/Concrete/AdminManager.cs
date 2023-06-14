using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminService _adminService;

        public AdminManager(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public void Create(Admin admin)
        {
            _adminService.Create(admin);    
        }

        public void Delete(Admin admin)
        {
            _adminService.Delete(admin);
        }

        public List<Admin> GetAll()
        {
            return _adminService.GetAll();  
        }

        public Admin GetById(int id)
        {
            return (_adminService.GetById(id)); 
        }

        public void Update(Admin admin)
        {
            _adminService.Update(admin);
        }
    }
}
