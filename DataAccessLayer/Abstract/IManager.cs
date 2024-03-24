using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IManager
    {
        //Create
        void Add(Manager p);

        //Read
        List<Manager> GetAll();
        Manager Get(int id);
        //T GetByID(short id);

        //Update
        void Update(Manager p);

        //Delete
        //void DeleteByID(short id);
        void Delete(int id);
    }
}
