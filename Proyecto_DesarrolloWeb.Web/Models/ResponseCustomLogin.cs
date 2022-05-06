namespace Proyecto_DesarrolloWeb.Web.Models
{
    public class ResponseCustomLogin
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public User? Data { get; set; }
    }
}
