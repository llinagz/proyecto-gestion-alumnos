
using AccesoDatos.Operaciones;

AlumnoDAO opAlumno = new AlumnoDAO();

//Insercion de datos
//opAlumno.Insertar("653726J", "Javier Llinares", "Calle Esperanza 8", 33, "jllinares@correo.com");
//opAlumno.Actualizar(1002, "653726J", "Javier Llinares Barral", "Calle Argentina 8", 33, "jllinares@correo.com");
opAlumno.Eliminar(1002);

var alumnos = opAlumno.SeleccionarTodos();

foreach (var alumno in alumnos)
{
    Console.WriteLine(alumno.Nombre);
}

Console.WriteLine("#######");

var alumnoSeleccionado = opAlumno.Seleccionar(1);
if(alumnoSeleccionado != null)
{
    Console.WriteLine($"El alumno con id = 1 es: {alumnoSeleccionado.Nombre}");
}
else
{
    Console.WriteLine("No se ha encontrado el alumno");
}

Console.WriteLine("#######");

var alumnosAsignatura = opAlumno.SeleccionarAlumnosAsignaturas();
foreach(var alumnoAsignatura in alumnosAsignatura)
{
    Console.WriteLine($"{alumnoAsignatura.NombreAlumno} -> {alumnoAsignatura.NombreAsignatura}");
}