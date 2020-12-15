using System;
using System.ComponentModel.DataAnnotations;
using Entity;

namespace Vista.Models {
    public class HojaDeVidaInputModel {
        public int IdHojaDeVida { get; set; }

        [Required (ErrorMessage = "La identificacion es requerida")]
        public string Identificacion { get; set; }

        [Required (ErrorMessage = "La fecha de solicitud es requerida")]
        public DateTime FechaDeSolicitud { get; set; }

        [Required (ErrorMessage = "El programa es requerido")]
        public string Programa { get; set; }

        [Required (ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required (ErrorMessage = "El primer apellido es requerido")]
        public string PrimerApellido { get; set; }

        [Required (ErrorMessage = "El segundo apellido es requerido")]
        public string SegundoApellido { get; set; }

        [Required (ErrorMessage = "La fecha de nacimiento es requerida")]
        public DateTime FechaDeNacimiento { get; set; }

        [Required (ErrorMessage = "El lugar de nacimiento es requerido")]
        public string LugarDeNacimiento { get; set; }

        [Required (ErrorMessage = "El estado civil es requerido")]
        public string EstadoCivil { get; set; }

        [Required (ErrorMessage = "La dirección actual es requerida")]
        public string DireccionActual { get; set; }

        [Required (ErrorMessage = "El número de teléfono es requerido")]
        public string Telefono { get; set; }

        [Required (ErrorMessage = "La eps actual es requerida")]
        public string EpsActual { get; set; }

        [Required (ErrorMessage = "El correo electrónico es requerido")]
        public string CorreoElectronico { get; set; }

        [Required (ErrorMessage = "La ciudad actual es requerida")]
        public string CiudadActual { get; set; }

        [Required (ErrorMessage = "Los estudios realizados son requeridos")]
        public string EstudiosRealizados { get; set; }

        [Required (ErrorMessage = "Los idiomas son requeridos")]
        public string Idiomas { get; set; }

        [Required (ErrorMessage = "Los proyectos realizados son requeridos")]
        public string ProyectosRealizados { get; set; }

        [Required (ErrorMessage = "Los conocimientos prácticos de informática son requeridos")]
        public string ConocimientoPracticaInformatica { get; set; }

        [Required (ErrorMessage = "Los seminarios y los cursos asistidos son requeridos")]
        public string SeminarioYCursosAsistidos { get; set; }

        [Required (ErrorMessage = "Las distinciones y honores recibidos son requeridos")]
        public string DistincionesYHonoresRecibidos { get; set; }

        [Required (ErrorMessage = "La experiencia laboral es requerida")]
        public string ExperienciaLaboral { get; set; }

        [Required (ErrorMessage = "Las areas de interes para prácticas son requeridas")]
        public string AreasDeInteresParaPracticas { get; set; }

    }
    public class HojaDeVidaViewModel : HojaDeVidaInputModel {
        public HojaDeVidaViewModel () {

        }
        public HojaDeVidaViewModel (HojaDeVida hojaDeVida) {
            IdHojaDeVida = hojaDeVida.IdHojaDeVida;
            Identificacion = hojaDeVida.Identificacion;
            FechaDeSolicitud = hojaDeVida.FechaDeSolicitud;
            Programa = hojaDeVida.Programa;
            Nombre = hojaDeVida.Nombre;
            PrimerApellido = hojaDeVida.PrimerApellido;
            SegundoApellido = hojaDeVida.SegundoApellido;
            FechaDeNacimiento = hojaDeVida.FechaDeNacimiento;
            LugarDeNacimiento = hojaDeVida.LugarDeNacimiento;
            EstadoCivil = hojaDeVida.EstadoCivil;
            DireccionActual = hojaDeVida.DireccionActual;
            Telefono = hojaDeVida.Telefono;
            EpsActual = hojaDeVida.EpsActual;
            CorreoElectronico = hojaDeVida.CorreoElectronico;
            CiudadActual = hojaDeVida.CiudadActual;
            EstudiosRealizados = hojaDeVida.EstudiosRealizados;
            Idiomas = hojaDeVida.Idiomas;
            ProyectosRealizados = hojaDeVida.ProyectosRealizados;
            ConocimientoPracticaInformatica = hojaDeVida.ConocimientoPracticaInformatica;
            SeminarioYCursosAsistidos = hojaDeVida.SeminarioYCursosAsistidos;
            DistincionesYHonoresRecibidos = hojaDeVida.DistincionesYHonoresRecibidos;
            ExperienciaLaboral = hojaDeVida.ExperienciaLaboral;
            AreasDeInteresParaPracticas = hojaDeVida.AreasDeInteresParaPracticas;

        }

    }

}