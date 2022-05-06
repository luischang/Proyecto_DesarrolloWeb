using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_DesarrolloWeb.Web.Models
{
    public partial class PetAdoption
    {
        public int Id { get; set; }
        public int? IdPet { get; set; }
        public int? IdUser { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}
