using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_DesarrolloWeb.Web.Models
{
    public class ReportUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int petsCount { get; set; }
    }
}
