using System.ComponentModel.DataAnnotations;
using System;
namespace Entity
{
    public class HojaDeVida
    {

        [Key]
        public int IdHojaDeVida { get; set; }
        public string Identificacion { get; set; }
        public DateTime FechaDeSolicitud { get; set; }
        public string Programa { get; set; }
        public string Nombre { get; set; } 
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string LugarDeNacimiento { get; set; }
        public string EstadoCivil { get; set; }
        public string DireccionActual { get; set; }
        public string Telefono { get; set; }
        public string EpsActual { get; set; }
        public string CorreoElectronico { get; set; }
        public string CiudadActual { get; set; }
        public string EstudiosRealizados { get; set; }
        public string Idiomas { get; set; }
        public string ProyectosRealizados { get; set; }
        public string ConocimientoPracticaInformatica { get; set; }
        public string SeminarioYCursosAsistidos { get; set; }
        public string DistincionesYHonoresRecibidos { get; set; }
        public string ExperienciaLaboral { get; set; }
        public string AreasDeInteresParaPracticas { get; set; }


    }
}