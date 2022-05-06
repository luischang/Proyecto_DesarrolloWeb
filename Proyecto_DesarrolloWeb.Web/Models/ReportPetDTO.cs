using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_DesarrolloWeb.Web.Models
{
    public class ReportPetDTO
    {
        public int IdPet { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string LostStatus { get; set; }
        public string AdoptionStatus { get; set; }
        public string Type { get; set; }
        public string Age { get; set; }
        public ICollection<byte[]> Photo { get; set; }
    }
}
