using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISupportFormService
    {
        void SupportFormAdd(SupportForm supportForm);
        List<SupportForm> GetSupportForms();
        void SupportFormDelete(int id);
        void UpdateSupportFormStatus(int id, string status);
    }
}
