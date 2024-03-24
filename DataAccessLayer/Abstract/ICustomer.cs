﻿using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICustomer 
    {
        //Create
        void Add(Customer p);

        //Read
        List<Customer> GetAll();
        //T GetByID(short id);

        //Update
        void Update(Customer p);

        //Delete
        //void DeleteByID(short id);
        void Delete(int id);
    }
}