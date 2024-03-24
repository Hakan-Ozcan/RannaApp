using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ManagerManager : IManagerService
    {
        IManager _manager;
        public ManagerManager(IManager manager)
        {
            _manager = manager;
        }
       

        public List<Manager> GetManagers()
        {
            return _manager.GetAll();
        }

        public void ManagerAdd(Manager manager)
        {
            _manager.Add(manager);
        }

        public void ManagerDelete(int id)
        {
            _manager.Delete(id);
        }

        public void ManagerUpdate(Manager manager)
        {
            _manager.Update(manager);
        }
    }
}
