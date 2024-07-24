using API.Models;

namespace API.Repository
{
    public interface IEmpleadoRepository
    {
        Task<List<Empleado>> GetAll();
        Task<Empleado> GetEmpleadoById(int id);
        Task<bool> CreateEmpleado(Empleado item);
        Task<bool> UpdateEmpleado(Empleado item);
        Task<object> DeleteEmpleado(int item);
    }
}
