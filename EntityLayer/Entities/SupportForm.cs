using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class SupportForm
    {
        [Key]
        public int id { get; set; }
        public string user { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public DateTime date { get; set; }
        public string formStatu { get; set; }
    }
}
