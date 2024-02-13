using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private AlumnoDAO alumnoDAO = new AlumnoDAO();

        [HttpGet("alumnosProfesor")]
        public List<AlumnoProfesor> GetAlumnosProfesor(string usuarioProfesor)
        {
            return alumnoDAO.SeleccionarAlumnosProfesor(usuarioProfesor);
        }

        [HttpGet("alumno")]
        public Alumno GetAlumno(int id)
        {
            return alumnoDAO.Seleccionar(id);
        }

        [HttpPut("alumno")]
        public bool ActualizarAlumno([FromBody] Alumno alumno)
        {
            return alumnoDAO.Actualizar(alumno.Id, alumno.Dni, alumno.Nombre, alumno.Direccion, alumno.Edad, alumno.Email);
        }

        [HttpPost("alumno")]
        public bool InsertarMatricula([FromBody] Alumno alumno, int idAsignatura)
        {
            return alumnoDAO.InsertarYMatricular(alumno.Dni, alumno.Nombre, alumno.Direccion, alumno.Edad, alumno.Email, idAsignatura);
        }

        [HttpDelete("alumno")]
        public bool EliminarAlumno(int id)
        {
            return alumnoDAO.EliminarAlumno(id);
        }
    }
}
