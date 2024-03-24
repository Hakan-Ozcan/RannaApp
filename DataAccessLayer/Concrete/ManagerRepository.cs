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
    public class ManagerRepository : IManager
    {
        private readonly Context _context;

        public ManagerRepository(Context context)
        {
            _context = context;
        }

        public void Add(Manager p)
        {
            _context.Set<Manager>().Add(p);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Set<Manager>().Find(id);
            if (entity != null)
            {
                _context.Set<Manager>().Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<Manager> GetAll()
        {
            return _context.Set<Manager>().ToList();
        }

        public void Update(Manager p)
        {
            _context.Set<Manager>().Update(p);
            _context.SaveChanges();
        }
    }
}
