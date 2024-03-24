using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IForm 
    {
        //Create
        void Add(SupportForm p);

        //Read
        List<SupportForm> GetAll();
        //T GetByID(short id);

        //Update
        void Update(SupportForm p);

        //Delete
        //void DeleteByID(short id);
        void Delete(int id);
    }
}
