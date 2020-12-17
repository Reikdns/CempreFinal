using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Logica;
using Datos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Vista.Models;

namespace Vista.Controllers {

    [Route ("api/[controller]")]
    [ApiController]

    public class HojaDeVidaController : ControllerBase {
        private readonly HojaDeVidaService _hojaDeVidaService;

        public HojaDeVidaController (CempreContext context)
        { 
            _hojaDeVidaService = new HojaDeVidaService (context);
        }
        
        [HttpGet]
        public IEnumerable<HojaDeVidaViewModel> Gets()
        {
            var hojasDeVida = _hojaDeVidaService.ConsultarTodos().Select(p=> new HojaDeVidaViewModel(p));
            return hojasDeVida;
        }

        
        [HttpGet("{idHojaDeVida}")]
        public ActionResult<HojaDeVidaViewModel> Get(int idHojaDeVida)
        {
            var hojaDeVida = _hojaDeVidaService.BuscarPorId(idHojaDeVida);
            if (hojaDeVida == null) return NotFound();
            var hojaDeVidaViewModel = new HojaDeVidaViewModel(hojaDeVida);
            return hojaDeVidaViewModel;
        }


        [HttpPost]
        public ActionResult<HojaDeVidaViewModel> Post(HojaDeVidaInputModel hojaDeVidaInput)
        {
            HojaDeVida hojaDeVida = MapearHojaDeVida(hojaDeVidaInput);
            var response = _hojaDeVidaService.Guardar(hojaDeVida);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.HojaDeVida);
        }

        [HttpDelete("{idHojaDeVida}")]
        public ActionResult<string> Delete(int idHojaDeVida)
        {
            string mensaje = _hojaDeVidaService.Eliminar(idHojaDeVida);
            return Ok(mensaje);
        }

        private HojaDeVida MapearHojaDeVida(HojaDeVidaInputModel hojaDeVidaInput)
        {
            HojaDeVida hojaDeVida = new HojaDeVida
            {
            IdHojaDeVida=hojaDeVidaInput.IdHojaDeVida,
            Identificacion=hojaDeVidaInput.Identificacion, 
            FechaDeSolicitud=hojaDeVidaInput.FechaDeSolicitud,
            Programa=hojaDeVidaInput.Programa,
            Nombre=hojaDeVidaInput.Nombre,
            PrimerApellido=hojaDeVidaInput.PrimerApellido,
            SegundoApellido=hojaDeVidaInput.SegundoApellido,
            FechaDeNacimiento=hojaDeVidaInput.FechaDeNacimiento,
            LugarDeNacimiento=hojaDeVidaInput.LugarDeNacimiento,
            EstadoCivil=hojaDeVidaInput.EstadoCivil,
            DireccionActual=hojaDeVidaInput.DireccionActual,
            Telefono=hojaDeVidaInput.Telefono,
            EpsActual=hojaDeVidaInput.EpsActual,
            CorreoElectronico=hojaDeVidaInput.CorreoElectronico,
            CiudadActual=hojaDeVidaInput.CiudadActual,
            EstudiosRealizados=hojaDeVidaInput.EstudiosRealizados,
            Idiomas=hojaDeVidaInput.Idiomas,
            ProyectosRealizados=hojaDeVidaInput.ProyectosRealizados,
            ConocimientoPracticaInformatica=hojaDeVidaInput.ConocimientoPracticaInformatica,
            SeminariosYCursosAsistidos=hojaDeVidaInput.SeminariosYCursosAsistidos,
            DistincionesYHonoresRecibidos=hojaDeVidaInput.DistincionesYHonoresRecibidos,
            ExperienciaLaboral=hojaDeVidaInput.ExperienciaLaboral,
            AreasDeInteresParaPracticas=hojaDeVidaInput.AreasDeInteresParaPracticas
            };
            return hojaDeVida; 
        }


    }
}

