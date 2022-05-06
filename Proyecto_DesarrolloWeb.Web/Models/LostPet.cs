using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_DesarrolloWeb.Web.Models
{
    public partial class LostPet
    {
        public int Id { get; set; }
        public int? IdUser { get; set; }
        public int? IdPet { get; set; }
        public DateTime? DateOfLoss { get; set; }
        public string DescriptionOfLoss { get; set; }
        public DateTime? DateOfFound { get; set; }
        public string DescriptionOfFound { get; set; }
        public string Status { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Name { get; set; }
    }
}
