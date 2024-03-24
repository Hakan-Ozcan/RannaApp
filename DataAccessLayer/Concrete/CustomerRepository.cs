using DataAccessLayer.Abstract;
using DataAccessLayer.DatabaseContext;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Update(Customer p)
        {
            _context.Set<Customer>().Update(p);
            _context.SaveChanges();
        }
    }
}
