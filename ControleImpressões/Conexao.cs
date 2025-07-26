
using System.Data.SqlClient;

namespace ControleImpressões
{
    public class Conexao
    {
        public SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ana.rocha11\\MEUBANCO\\MEUBANCO.mdf;Integrated Security=True;Connect Timeout=30");

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
