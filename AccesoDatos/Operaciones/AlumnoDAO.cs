using AccesoDatos.Context;
using AccesoDatos.Models;

namespace AccesoDatos.Operaciones
{
    public class AlumnoDAO
    {
        public GestorAlumnosContext _context = new GestorAlumnosContext();

        public List<Alumno> SeleccionarTodos()
        {
            var alumnos = _context.Alumnos.ToList();
            return alumnos;
        }
    }
}
