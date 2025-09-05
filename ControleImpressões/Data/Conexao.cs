

using System.Data.SqlClient;

namespace Escola.Data
{
    public class Conexao
    {
  
        public SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BANCOJP;Data Source=ANATRICE\\MSSQLSERVER01");

        public SqlConnection ObterConexao()
        {
            return conn;
        }

        public void Conectar()
        {
            conn.Open();
        }

        public void Desconectar()
        {
            conn.Close();
        }
    }
}

