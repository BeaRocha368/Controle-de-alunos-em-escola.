
using System.Data.SqlClient;

namespace ControleImpressões
{
    public class Conexao
    {
        public SqlConnection conn = new SqlConnection("Int e g r a t e d   S e c u r i t y = S S P I ; P e r s i s t   S e c u r i t y   I n f o = F a l s e ; I n i t i a l   C a t a l o g = T e s t e C o n e x a o ; D a t a   S o u r c e = l o c a l h o s t \\ M S S Q L S E R V E R 0 1 \r\n");

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
