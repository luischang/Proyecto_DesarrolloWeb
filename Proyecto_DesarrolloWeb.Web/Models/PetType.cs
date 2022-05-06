using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto_DesarrolloWeb.Web.Models
{
    public partial class PetType
    {
        public PetType()
        {
            Pet = new HashSet<Pet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Pet> Pet { get; set; }
    }

}
