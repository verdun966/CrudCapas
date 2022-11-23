using System.Data;
using System.Data.SqlClient;

namespace DatosAcceso.Conexion
{
    public class Connection_DB
    {
        private SqlConnection sql = new SqlConnection("Data Source=DESKTOP-B92RK5F\\SQLEXPRESS;Initial Catalog=Crud_N_Capas;Integrated Security=True");

        public SqlConnection OpenConnection()
        {
            if(sql.State == ConnectionState.Closed) sql.Open();
            return sql;
        }

        public SqlConnection CloseConnection()
        {
            if (sql.State == ConnectionState.Open) sql.Close();
            return sql;
        }
    }
}
