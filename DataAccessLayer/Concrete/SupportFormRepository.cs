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
    public class SupportFormRepository : ISupportForm
    {
        private readonly Context _context;

        public SupportFormRepository(Context context)
        {
            _context = context;
        }
        public void Add(SupportForm p)
        {
            _context.Set<SupportForm>().Add(p);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Set<SupportForm>().Find(id);
            if (entity != null)
            {
                _context.Set<SupportForm>().Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<SupportForm> GetAll()
        {
            return _context.Set<SupportForm>().ToList();
        }
        public SupportForm Get(int id)
        {
            return _context.Set<SupportForm>().FirstOrDefault(m => m.Id == id);
        }

        public void Update(int id, SupportForm updatedForm)
        {
            var existingForm = _context.Set<SupportForm>().Find(id);

            if (existingForm != null)
            {
                existingForm.User = updatedForm.User;
                existingForm.Subject = updatedForm.Subject;
                existingForm.Message = updatedForm.Message;
                existingForm.Date = updatedForm.Date;
                existingForm.FormStatus = updatedForm.FormStatus;

                _context.SaveChanges();
            }
        }
    }
}
