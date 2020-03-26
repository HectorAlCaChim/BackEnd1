using System.Text.Json.Serialization;
using Scm.Domain;
namespace Scm.Domain
{
    public class Horarios 
    {
        public string Clave{get; set;}
        public string Dias{get; set;}
        public string Salon{get; set;}
        [JsonIgnore]
        public Materias Materias { get; set; }
        public string Materia {get; set;}
        [JsonIgnore]
        public Maestros Maestros { get; set; }
        public string MaestrosRfc {get; set;}
    }
}