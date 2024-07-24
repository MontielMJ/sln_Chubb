using System.Data;
using System.Data.SqlClient;

namespace API.DAO
{
    public class ActionDAO : IActionDAO
    {
        private readonly IConfiguration _configuration;

        public ActionDAO(IConfiguration configuration)
        {

            _configuration = configuration;
        }


        SqlCommand command = new SqlCommand();
        SqlConnection sqlConnection;

        public void connectionOpen()
        {

            sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionServer"));

        }


        public DataTable EjecutaSP(string storeProcedure, List<SqlParameter> listParameters = null)
        {

            DataTable dt_Data = new DataTable();
            using (SqlConnection sql_connection = new SqlConnection(_configuration.GetConnectionString("ConnectionServer")))
            {
                using (SqlDataAdapter sql_adapter = new SqlDataAdapter(storeProcedure, sql_connection))
                {
                    try
                    {
                        sql_connection.Open();
                        sql_adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sql_adapter.SelectCommand.CommandTimeout = 100;
                        if (listParameters != null)
                        {
                            foreach (SqlParameter Parameter in listParameters)
                            {
                                sql_adapter.SelectCommand.Parameters.Add(Parameter);
                            }
                        }

                        sql_adapter.Fill(dt_Data);
                    }
                    catch (Exception ex)
                    {
                        //Log
                        dt_Data.Columns.Add("Estatus_Respuesta", typeof(string));
                        dt_Data.Columns.Add("Mensaje_Respuesta", typeof(string));
                        DataRow MyRow = dt_Data.NewRow();

                        MyRow["Estatus_Respuesta"] = "false";


                        dt_Data.Rows.Add(MyRow);
                    }
                    finally
                    {
                        sql_connection.Close();
                    }
                }
            }
            return dt_Data;

        }


    }
}
