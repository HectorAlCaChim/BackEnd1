using System.ComponentModel.DataAnnotations;
namespace Scm.Controllers.Dtos
{
    public class EstudiantesDto
    {
        ///AQUI SE PIDEN LOS DATOS DE ENTRADA DEL JASON
        [Required]
        [MinLength (1)]
        [MaxLength(30)]
        public string Nombre{ get; set; }
        [Required]
        public string Apellido1{ get; set; }
        [Required]
        public string Apellido2{ get; set; }
        public int Edad{ get; set; }
        public string Genero{get; set;}
    }
    public class EstudiantesResponseDto {
        public int IdEstudiantes { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
         public string Apellido2 { get; set; }
        public int Edad{ get; set; }
        public string Genero {get; set;}
    }
    public class EstudiantesUpdateDto
    {
        public int IdEstudiantes { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int Edad { get; set; }
        public string Genero{set; get; }
    }
}