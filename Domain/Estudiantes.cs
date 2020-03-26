namespace Scm.Domain
{
    public class Estudiantes
    {
        //se ponen los elementos de la tabla Estudiantes
        public int IdEstudiantes{get; set;}
        public string Nombre{get; set;}//primera columna 
        public string Apellido1 { get; set; }//segunda columna
        public string Apellido2 { get; set; }//tercera columna
        public int Edad { get; set; }//tercera columna
        public string Genero {get; set;}
    }
    
}