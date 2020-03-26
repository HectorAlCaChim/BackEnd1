using System.Collections.Generic;
using System.Text.Json.Serialization;
using Scm.Domain;
namespace Scm.Controllers.Dtos
{
    public class MaestrosDto
    {  
        public string Rfc {get; set;}
        public string Nombres {get; set;}
        public string Apellidos {get; set;}
        public string Email {get; set;}
    }
    public class MaestrosResponseDto
    {  
        public string Rfc {get; set;}
        public string Nombres {get; set;}
        public string Apellidos {get; set;}
        public string Email {get; set;}
        public List<Horarios> Horarios {get; set;}
    }
    
}