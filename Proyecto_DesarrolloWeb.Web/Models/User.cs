using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_DesarrolloWeb.Web.Models
{
    public partial class User
    {
        public User()
        {
            Pet = new HashSet<Pet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Contra { get; set; }
        public int Enabled { get; set; }
        public int Admin { get; set; }

        public virtual ICollection<Pet> Pet { get; set; }
    }
}