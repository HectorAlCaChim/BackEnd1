using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using scm.Service;

namespace Scm.Domain
{
    public class Maestros
    {
        public string Rfc {get; set;}
        public string Nombres {get; set;}
        public string Apellidos {get; set;}
        public string Email {get; set;}
        [JsonIgnore]
        public List<Horarios> Horarios {get; set;}
        public void setDetalles(List<Horarios> details)
        {
            Horarios = details.Where(x => x.MaestrosRfc == Rfc).ToList();
            Console.WriteLine("entro");
        }
    }
    
}