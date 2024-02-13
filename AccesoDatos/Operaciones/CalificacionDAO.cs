using AccesoDatos.Context;
using AccesoDatos.Models;

namespace AccesoDatos.Operaciones
{
    public class CalificacionDAO
    {
        public GestorAlumnosContext _context = new GestorAlumnosContext();

        public List<Calificacion> Seleccionar(int idMatricula)
        {
            var calificaciones = _context.Calificacions.Where(c => c.MatriculaId == idMatricula).ToList();
            return calificaciones;
        }

        public bool AgregarCalificacion(Calificacion calificacion)
        {
            try
            {
                _context.Calificacions.Add(calificacion);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EliminarCalificacion(int idCalificacion)
        {
            try
            {
                var calificacion = _context.Calificacions.Where(c => c.Id == idCalificacion).FirstOrDefault();
                if(calificacion != null)
                {
                    _context.Calificacions.Remove(calificacion);
                    _context.SaveChanges();
                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch 
            { 
                return false; 
            }
        }
    }
}
