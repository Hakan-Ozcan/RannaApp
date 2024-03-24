using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SupportFormManager : ISupportFormService
    {
        ISupportForm _supportform;
        public SupportFormManager(ISupportForm supportForm)
        {
            _supportform = supportForm;
        }
        public List<SupportForm> GetSupportForms()
        {
            return _supportform.GetAll();
        }

        public void SupportFormAdd(SupportForm supportForm)
        {
            _supportform.Add(supportForm);
        }

        public void SupportFormDelete(int id)
        {
            _supportform.Delete(id);
        }

        public void UpdateSupportFormStatus(int id, string status)
        {
            // GetById metodunun kullanılamadığı durumda, burada istenen destek formunu başka bir şekilde almanız gerekecek
            // Örneğin, GetAll metodunu kullanarak bir filtreleme yapabilirsiniz.
            List<SupportForm> supportForms = _supportform.GetAll();
            SupportForm supportFormToUpdate = supportForms.Find(s => s.Id == id);

            if (supportFormToUpdate != null)
            {
                supportFormToUpdate.FormStatus = status;
                _supportform.Update(id, supportFormToUpdate);
            }
            // supportFormToUpdate null ise veya güncellenemediyse bir hata işlemi gerçekleştirilebilir.
        }
    }
}
