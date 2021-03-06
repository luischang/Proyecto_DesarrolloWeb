using System;
using System.Collections.Generic;

namespace Proyecto_DesarrolloWeb.Web.Models
{
    public class ResponseCustom
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public object? Data { get; set; }
    }
    public class ResponseCustomGetMascotas
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public ICollection<ReportPetWithImageDTO> Data { get; set; }
    }
    public class ResponseCustomGetDetalleMascota
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public DetailPet Data { get; set; }
    }
    public class GetMascotas
    {
        public string Status { get; set; }
    }
    public class ReportPetWithImageDTO
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string LostStatus { get; set; }
        public string AdoptionStatus { get; set; }
        public string Type { get; set; }
        public string Age { get; set; }
        public ICollection<PetImage> PetImage { get; set; }
    }
    public class DetailPet
    {
        public int Id { get; set; }
        public int? IdUser { get; set; }
        public string? Email { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string LostStatus { get; set; }
        public string AdoptionStatus { get; set; }
        public string Type { get; set; }
        public string Age { get; set; }
        public ICollection<PetImage> PetImage { get; set; }
    }
}
