using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomer _customer;
        public CustomerManager(ICustomer customer)
        {
            _customer = customer;
        }

        public async Task<Customer> GetUserByUsernameAsync(string username)
        {
            // Kullanıcı adına göre kullanıcıyı getirme işlemi yapılacak.
            // Burada gerekli işlemleri gerçekleştirin.
            return await _customer.GetUserByUsernameAsync(username);
        }
        public void CustomerAdd(Customer customer)
        {
            _customer.Add(customer);
        }

        public void CustomerDelete(int id)
        {
            _customer.Delete(id);
        }

        public void CustomerUpdate(Customer customer)
        {
            _customer.Update(customer);
        }

        public List<Customer> GetCustomers()
        {
            return _customer.GetAll();
        }
        public Customer GetCustomer(int id)
        {
            return _customer.Get(id);
        }
    }
}
