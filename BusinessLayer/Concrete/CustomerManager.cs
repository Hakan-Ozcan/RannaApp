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
        private static bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1 == null || array2 == null || array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }
        private static byte[] GenerateHash(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                return pbkdf2.GetBytes(32);
            }
        }
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Salt ve hash'i ayrıştır
            string[] parts = hashedPassword.Split('|');
            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] hash = Convert.FromBase64String(parts[1]);

            // Verilen şifreyi ve salt'ı kullanarak hash'i yeniden oluştur ve karşılaştır
            byte[] inputHash = GenerateHash(password, salt);

            // Karşılaştırma işlemi
            return CompareByteArrays(hash, inputHash);
        }
        public async Task<bool> ValidateUserAsync(string username, string password)
        {
            // Kullanıcıyı veritabanından kullanıcı adına göre bul
            var user = await _customer.GetUserByUsernameAsync(username);

            // Kullanıcı yoksa, giriş başarısız
            if (user == null)
            {
                return false;
            }

            // Kullanıcının şifresini doğrula

            return VerifyPassword(password, user.password);
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
