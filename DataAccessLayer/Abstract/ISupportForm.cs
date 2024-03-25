using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ISupportForm
    {
        //Create
        void Add(SupportForm p);

        //Read
        List<SupportForm> GetAll();
        //T GetByID(short id);
        SupportForm Get(int id);
        //Update
        void Update(int id, SupportForm updatedForm);
        //Delete
        //void DeleteByID(short id);
        void Delete(int id);
    }
}
