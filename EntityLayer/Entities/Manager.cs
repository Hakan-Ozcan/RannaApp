using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Manager
    {
        [Key]
        public int id { get; set; }
        public string nameSurname { get; set; }
        public string adress { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
