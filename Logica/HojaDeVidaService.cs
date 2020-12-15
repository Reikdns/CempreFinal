using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;

namespace Logica {
    public class HojaDeVidaService {
        private readonly CempreContext _context;

        public HojaDeVidaService(CempreContext context) {
            _context = context;
        }

        public GuardarHojaDeVidaResponse Guardar (HojaDeVida hojaDeVida) {
            try {
                var hojaDeVidaBuscado = _context.HojasDeVida.Find (hojaDeVida.IdHojaDeVida);
                if (hojaDeVidaBuscado != null) {
                    return new GuardarHojaDeVidaResponse ("Error, la hoja de vida ya se encuentra registrada.");
                }

                _context.HojasDeVida.Add (hojaDeVida);
                _context.SaveChanges ();

                return new GuardarHojaDeVidaResponse (hojaDeVida);
            } catch (Exception e) {
                return new GuardarHojaDeVidaResponse ($"Error de la Aplicacion: {e.Message}");
            }
        }

        public List<HojaDeVida> ConsultarTodos () {
            List<HojaDeVida> hojasDeVida = _context.HojasDeVida.ToList ();
            return hojasDeVida;
        }

        public string Eliminar (int idHojadeVida) {
            try {
                var hojaDeVida = _context.HojasDeVida.Find (idHojadeVida);

                if (hojaDeVida != null) {
                    _context.HojasDeVida.Remove (hojaDeVida);
                    _context.SaveChanges ();
                    return ($"La hoja de vida #{hojaDeVida.Nombre}" +
                        $"perteneciente a {hojaDeVida.Nombre} {hojaDeVida.PrimerApellido} se ha eliminado satisfactoriamente.");
                } else {
                    return ($"No hay ninguna hoja de vida registradad con el número {hojaDeVida.IdHojaDeVida}");
                }
            } catch (Exception e) {

                return $"Error de la Aplicación: {e.Message}";
            }
        }

        public HojaDeVida BuscarPorId (int idHojadeVida) {
            HojaDeVida hojaDeVida = _context.HojasDeVida.Find(idHojadeVida);
            return hojaDeVida;
        }

        public int Totalizar () {
            return _context.HojasDeVida.Count ();
        }
    }

    public class GuardarHojaDeVidaResponse {
        public GuardarHojaDeVidaResponse (HojaDeVida hojaDeVida) {
            Error = false;
            HojaDeVida = hojaDeVida; 
        }
        public GuardarHojaDeVidaResponse (string mensaje) {
            Error = true;
            Mensaje = mensaje;
        }

        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public HojaDeVida HojaDeVida { get; set; }
    }
}