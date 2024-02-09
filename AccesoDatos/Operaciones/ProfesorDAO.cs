using AccesoDatos.Context;
using AccesoDatos.Models;

namespace AccesoDatos.Operaciones
{
    public class ProfesorDAO
    {
        public GestorAlumnosContext _context = new GestorAlumnosContext();

        public Profesor Login(string usuario, string pass)
        {
            var prof = _context.Profesors.Where(p => p.Usuario == usuario && p.Pass == pass).FirstOrDefault();
            return prof;
        }
    }
}
