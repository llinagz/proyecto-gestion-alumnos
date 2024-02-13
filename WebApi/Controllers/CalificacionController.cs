using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class CalificacionController : ControllerBase
    {
        private CalificacionDAO calificacionDAO = new CalificacionDAO();

        [HttpGet("calificaciones")]
        public List<Calificacion> Get(int idMatricula)
        {
            return calificacionDAO.Seleccionar(idMatricula);
        }

        [HttpPost("calificacion")]
        public bool Insertar([FromBody] Calificacion calificacion)
        {
            return calificacionDAO.AgregarCalificacion(calificacion);
        }

        [HttpDelete("calificacion")]
        public bool Eliminar(int idCalificacion)
        {
            return calificacionDAO.EliminarCalificacion(idCalificacion);
        }

    }
}
