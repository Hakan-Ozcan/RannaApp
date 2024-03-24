using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IManagerService
    {
        void ManagerAdd(Manager manager);
        List<Manager> GetManagers();
        void ManagerDelete(int id);
        void ManagerUpdate(Manager manager);
    }
}
