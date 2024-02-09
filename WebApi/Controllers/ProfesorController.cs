using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        ProfesorDAO profesorDAO = new ProfesorDAO();

        [HttpPost("autenticacion")]
        public string Login([FromBody] Profesor prof)
        {
            var profesor = profesorDAO.Login(prof.Usuario, prof.Pass);
            if(profesor != null)
            {
                return profesor.Usuario;
            }
            else
            {
                return null;
            }
        }
    }
}
