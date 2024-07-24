using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        public IConfiguration _configuration;

        public EmpleadosController(IConfiguration _configuration)
        {
                this._configuration = _configuration;   
        }

        // GET: api/<EmpleadosController>
        [HttpGet]
        public List<Empleado> Get()
        {
            EmpleadoRepository  empleadoRepository = new EmpleadoRepository(_configuration);
            var response=  empleadoRepository.GetAll();
            return response.Result;
        }

        // GET api/<EmpleadosController>/5
        [HttpGet("{id}")]
        public Empleado Get(int id)
        {
            EmpleadoRepository empleadoRepository = new EmpleadoRepository(_configuration);
            var response = empleadoRepository.GetEmpleadoById(id);
            return response.Result;
        }

        // POST api/<EmpleadosController>
        [HttpPost]
        public void Post([FromBody] Empleado empleado)
        {
            EmpleadoRepository empleadoRepository = new EmpleadoRepository(_configuration);
            var res = empleadoRepository.CreateEmpleado(empleado);
        }

        // PUT api/<EmpleadosController>/5
        [HttpPut]
        public void Put([FromBody] Empleado empleado)
        {
            EmpleadoRepository empleadoRepository = new EmpleadoRepository(_configuration);
            var res = empleadoRepository.UpdateEmpleado(empleado);
        }

        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            EmpleadoRepository empleadoRepository = new EmpleadoRepository(_configuration);
            var res = empleadoRepository.DeleteEmpleado(id);
        }
    }
}
