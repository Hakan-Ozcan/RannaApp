using DataAccessLayer.Abstract;
using DataAccessLayer.DatabaseContext;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class CustomerRepository : ICustomer
    {
        private readonly Context _context;

        public CustomerRepository(Context context)
        {
            _context = context;
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
        public async Task<bool> ValidateUserAsync(string username, string password)
        {
            // Kullanıcıyı veritabanından kullanıcı adına göre bul
            var user = await _context.Set<Customer>().FirstOrDefaultAsync(c => c.username == username);

            // Kullanıcı yoksa, giriş başarısız
            if (user == null)
            {
                return false;
            }

            // Kullanıcının şifresini doğrula
            bool isValidPassword = VerifyPassword(password, user.password);

            return isValidPassword;
        }


        public async Task<Customer> GetUserByUsernameAsync(string username)
        {
            // Kullanıcıyı veritabanından kullanıcı adına göre bul ve geri döndür
            return await _context.Set<Customer>().FirstOrDefaultAsync(c => c.username == username);
        }

        public void Add(Customer p)
        {
            _context.Set<Customer>().Add(p);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Set<Customer>().Find(id);
            if (entity != null)
            {
                _context.Set<Customer>().Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<Customer> GetAll()
        {
            return _context.Set<Customer>().ToList();
        }
        public Customer Get(int id)
        {
            return _context.Set<Customer>().FirstOrDefault(m => m.id == id);
        }

        public void Update(Customer p)
        {
            _context.Set<Customer>().Update(p);
            _context.SaveChanges();
        }
    }
}
