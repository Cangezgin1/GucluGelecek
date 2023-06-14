using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        void Create(Admin admin);
        void Delete(Admin admin);
        void Update(Admin admin);

        Admin GetById(int id);
        List<Admin> GetAll();
    }
}
