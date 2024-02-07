
using AccesoDatos.Operaciones;

AlumnoDAO opAlumno = new AlumnoDAO();
var alumnos = opAlumno.SeleccionarTodos();

foreach (var alumno in alumnos)
{
    Console.WriteLine(alumno.Nombre);
}
