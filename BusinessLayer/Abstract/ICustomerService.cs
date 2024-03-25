using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICustomerService
    {
        LoginResponse ValidateUserAsync(string username, string password);
        Task<Customer> GetUserByUsernameAsync(string username);
        void CustomerAdd(Customer customer);
        List<Customer> GetCustomers();
        Customer GetCustomer(int id);
        void CustomerDelete(int id);
        void CustomerUpdate(Customer customer);
      
    }
}
