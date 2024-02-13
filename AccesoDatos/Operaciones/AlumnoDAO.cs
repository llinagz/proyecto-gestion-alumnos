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

        public Alumno Seleccionar(int id)
        {
            var alumno = _context.Alumnos.Where(a => a.Id == id).FirstOrDefault();
            return alumno;
        }

        public Alumno SeleccionarPorDni(string dni)
        {
            var alumno = _context.Alumnos.Where(a => a.Dni == dni).FirstOrDefault();
            return alumno;
        }

        public bool Insertar(string dni, string nombre, string direccion, int edad, string email)
        {
            try
            {
                Alumno alumno = new Alumno();
                alumno.Dni = dni;
                alumno.Nombre = nombre;
                alumno.Direccion = direccion;
                alumno.Edad = edad;
                alumno.Email = email;

                _context.Alumnos.Add(alumno);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(int id, string dni, string nombre, string direccion, int edad, string email)
        {
            try
            {
                var alumno = Seleccionar(id);
                if(alumno == null)
                {
                    return false;
                }
                else
                {
                    alumno.Dni = dni;
                    alumno.Nombre = nombre;
                    alumno.Direccion = direccion;
                    alumno.Edad = edad;
                    alumno.Email = email;

                    _context.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                var alumno = Seleccionar(id);
                if (alumno == null)
                {
                    return false;
                }
                else
                {
                    _context.Alumnos.Remove(alumno);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<AlumnoAsignatura> SeleccionarAlumnosAsignaturas()
        {
            //select a.nombre, asig.nombre from alumno a
            //left join matricula m on m.alumnoId = a.id
            //left join asignatura asig on asig.id = m.asignaturaId
            var query = from a in _context.Alumnos
                        join m in _context.Matriculas on a.Id equals m.AlumnoId
                        join asig in _context.Asignaturas on m.AsignaturaId equals asig.Id
                        select new AlumnoAsignatura
                        {
                            NombreAlumno = a.Nombre,
                            NombreAsignatura = asig.Nombre
                        };

            return query.ToList();
        }

        public List<AlumnoProfesor> SeleccionarAlumnosProfesor(string usuarioProfesor)
        {
            var query = from a in _context.Alumnos
                        join m in _context.Matriculas on a.Id equals m.AlumnoId
                        join asig in _context.Asignaturas on m.AsignaturaId equals asig.Id
                        where asig.Profesor == usuarioProfesor
                        select new AlumnoProfesor
                        {
                            Id = a.Id,
                            Dni = a.Dni,
                            Nombre = a.Nombre,
                            Direccion = a.Direccion,
                            Edad = a.Edad,
                            Email = a.Email,
                            Asignatura = asig.Nombre
                        };

            return query.ToList();
        }

        public bool InsertarYMatricular(string dni, string nombre, string direccion, int edad, string email, int idAsignatura)
        {
            try
            {
                //Comprobar si existe o no al alumno
                var existe = SeleccionarPorDni(dni);

                if(existe == null)
                {
                    //Si no existe, lo insertamos en la tabla Alumno
                    Insertar(dni, nombre, direccion, edad, email);
                    //Lo matriculamos
                    var insertado = SeleccionarPorDni(dni);

                    Matricula matricula = new Matricula();
                    matricula.AlumnoId = insertado.Id;
                    matricula.AsignaturaId = idAsignatura;

                    _context.Matriculas.Add(matricula);
                    _context.SaveChanges();
                }
                //Si existe
                else
                {
                    Matricula matricula = new Matricula();
                    matricula.AlumnoId = existe.Id;
                    matricula.AsignaturaId = idAsignatura;

                    _context.Matriculas.Add(matricula);
                    _context.SaveChanges();

                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EliminarAlumno(int id)
        {
            try
            {
                var alumno = _context.Alumnos.Where(a => a.Id == id).FirstOrDefault();
                if (alumno != null)
                {
                    var matriculas = _context.Matriculas.Where(m => m.AlumnoId == id).ToList();
                    foreach(Matricula matricula in matriculas)
                    {
                        var calificaciones = _context.Calificacions.Where(c => c.MatriculaId == matricula.Id);
                        _context.Calificacions.RemoveRange(calificaciones);
                    }
                    _context.Matriculas.RemoveRange(matriculas);
                    _context.Alumnos.Remove(alumno);
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
