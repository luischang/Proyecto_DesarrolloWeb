using System.Collections.Generic;

namespace Proyecto_DesarrolloWeb.Web.Models
{
    public class ResponseCustomUser
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public List<User> Data { get; set; }
    }
}
