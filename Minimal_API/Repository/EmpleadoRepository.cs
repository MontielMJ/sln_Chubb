using Minimal_API.Models;

namespace Minimal_API.Repository
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        public IConfiguration _configuration;
        public EmpleadoRepository(IConfiguration _configuration)
        {
            this._configuration = _configuration;
        }
        public async Task<bool> CreateEmpleado(Empleado item)
        {
       
           throw new NotImplementedException();
        }


        public async Task<object> DeleteEmpleado(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Empleado>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Empleado> GetEmpleadoById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateEmpleado(Empleado item)
        {
            throw new NotImplementedException();
        }

    }
}
