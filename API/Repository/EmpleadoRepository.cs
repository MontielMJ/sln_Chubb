
using API.DAO;
using API.Models;
using System.Data.SqlClient;
using System.Data;

namespace API.Repository
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
            ActionDAO da = new ActionDAO(_configuration);
            List<SqlParameter> Parametros = new List<SqlParameter>();
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@foto",
                SqlDbType = SqlDbType.VarChar,
                Value = item.Fotografia,
            });
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@nombre",
                SqlDbType = SqlDbType.VarChar,
                Value = item.Nombre
            });
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@apellido",
                SqlDbType = SqlDbType.VarChar,
                Value = item.Apellido
            });
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@puesto",
                SqlDbType = SqlDbType.Int,
                Value = item.PuestoId
            });
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@fechaNac",
                SqlDbType = SqlDbType.Date,
                Value = item.FechaNacimiento
            });
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@fechaCon",
                SqlDbType = SqlDbType.Date,
                Value = item.FechaContratacion
            });
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@direccion",
                SqlDbType = SqlDbType.VarChar,
                Value = item.Direccion
            });
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@telefono",
                SqlDbType = SqlDbType.VarChar,
                Value = item.Telefono
            });
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@correo",
                SqlDbType = SqlDbType.VarChar,
                Value = item.CorreoElectronico
            });
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@estado",
                SqlDbType = SqlDbType.VarChar,
                Value = item.EstadoId
            });

            string query = "sp_InsEmpleado";
            DataTable MyDataTable = da.EjecutaSP(query, Parametros);

            return true;
        }

        public async Task<object> DeleteEmpleado(int id)
        {
            ActionDAO actionDAO = new ActionDAO(_configuration);
            List<SqlParameter> Parametros = new List<SqlParameter>();
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.VarChar,
                Value = id,
            });
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@estado",
                SqlDbType = SqlDbType.VarChar,
                Value = 2, //Inactivo
            });


            string query = "sp_DelEmpleado";
            DataTable MyDataTable = actionDAO.EjecutaSP(query, Parametros);

            return true;
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Empleado>> GetAll()
        {
            ActionDAO action = new ActionDAO(_configuration);

            string query = "sp_GetEmpleados";
            DataTable MyDataTable = action.EjecutaSP(query, null);

            List<Empleado> usuarios = MyDataTable.AsEnumerable().Select(row => new Empleado
            {
                Id = row.Field<int>("Id"),
                Fotografia = row.Field<string>("Fotografia"),
                Nombre = row.Field<string>("Nombre"),
                Apellido = row.Field<string>("Apellido"),
                PuestoId = row.Field<Int32>("PuestoId"),
                FechaContratacion = row.Field<DateTime>("FechaContratacion"),
                FechaNacimiento = row.Field<DateTime>("FechaNacimiento"),
                Direccion = row.Field<string>("Direccion"),
                Telefono = row.Field<string>("Telefono"),
                CorreoElectronico = row.Field<string>("CorreoElectronico"),
                EstadoId = row.Field<Int32>("EstadoId"),

            }).ToList();

            return usuarios;
        }

        public async Task<Empleado> GetEmpleadoById(int id)
        {
            ActionDAO action = new ActionDAO(_configuration);

            string query = "sp_GetEmpleados";
            List<SqlParameter> Parametros = new List<SqlParameter>();
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@Id",
                SqlDbType = SqlDbType.VarChar,
                Value = id,
            });
            DataTable MyDataTable = action.EjecutaSP(query, Parametros);
            List<Empleado> usuarios = MyDataTable.AsEnumerable().Select(row => new Empleado
            {
                Id = row.Field<int>("Id"),
                Fotografia = row.Field<string>("Fotografia"),
                Nombre = row.Field<string>("Nombre"),
                Apellido = row.Field<string>("Apellido"),
                PuestoId = row.Field<Int32>("PuestoId"),
                FechaContratacion = row.Field<DateTime>("FechaContratacion"),
                FechaNacimiento = row.Field<DateTime>("FechaNacimiento"),
                Direccion = row.Field<string>("Direccion"),
                Telefono = row.Field<string>("Telefono"),
                CorreoElectronico = row.Field<string>("CorreoElectronico"),
                EstadoId = row.Field<Int32>("EstadoId"),

            }).ToList();

            return usuarios.FirstOrDefault();
        }

        public async Task<bool> UpdateEmpleado(Empleado item)
        {
            ActionDAO da = new ActionDAO(_configuration);
            List<SqlParameter> Parametros = new List<SqlParameter>();
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.VarChar,
                Value = item.Id,
            });
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@foto",
                SqlDbType = SqlDbType.VarChar,
                Value = item.Fotografia,
            });
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@nombre",
                SqlDbType = SqlDbType.VarChar,
                Value = item.Nombre
            });
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@apellido",
                SqlDbType = SqlDbType.VarChar,
                Value = item.Apellido
            });
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@puesto",
                SqlDbType = SqlDbType.Int,
                Value = item.PuestoId
            });
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@fechaNac",
                SqlDbType = SqlDbType.Date,
                Value = item.FechaNacimiento
            });
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@fechaCon",
                SqlDbType = SqlDbType.Date,
                Value = item.FechaContratacion
            });
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@direccion",
                SqlDbType = SqlDbType.VarChar,
                Value = item.Direccion
            });
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@telefono",
                SqlDbType = SqlDbType.VarChar,
                Value = item.Telefono
            });
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@correo",
                SqlDbType = SqlDbType.VarChar,
                Value = item.CorreoElectronico
            });
            Parametros.Add(new SqlParameter()
            {
                ParameterName = "@estado",
                SqlDbType = SqlDbType.VarChar,
                Value = item.EstadoId
            });
            string query = "sp_UpdEmpleado";
            DataTable MyDataTable = da.EjecutaSP(query, Parametros);

            return true;
        }
    }
}
