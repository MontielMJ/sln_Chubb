using System.Data;
using System.Data.SqlClient;

namespace API.DAO
{
    public interface IActionDAO
    {
        public void connectionOpen();
        public DataTable EjecutaSP(string storeProcedure, List<SqlParameter> listParameters = null);
    }
}
