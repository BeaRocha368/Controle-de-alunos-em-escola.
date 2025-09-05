using System.Data.SqlClient;

namespace Escola.Data
{
    public class AlunoRepositorio
    {
        private SqlConnection _conn;
        public AlunoRepositorio(SqlConnection conn)
        {
            _conn = conn;
        }

        public string InserirAluno(Aluno aluno) // Fix: Change parameter type from 'Alunos' to 'Aluno'
        {
            try
            {
                string sql =
                            """
                        INSERT INTO Alunos (
                        Nome, 
                        Idade,
                        Cpf, 
                        DataNascimento, 
                        Cep, 
                        Endereco, 
                        Numero,
                        Bairro,
                        Cidade,
                        Estado,
                        Nota1, 
                        Nota2
                        ) VALUES (
                        @Nome, 
                        @Idade, 
                        @Cpf, 
                        @DataNascimento,
                        @Cep,
                        @Endereco, 
                        @Numero,
                        @Bairro,
                        @Cidade,
                        @Estado,
                        @Nota1, 
                        @Nota2
                        );
                        """;

                SqlCommand comando = new SqlCommand(sql, _conn);
                comando.Parameters.AddWithValue("@Nome", aluno.Nome);
                comando.Parameters.AddWithValue("@Idade", aluno.Idade);
                comando.Parameters.AddWithValue("@Cpf", aluno.Cpf);
                comando.Parameters.AddWithValue("@DataNascimento", aluno.DataNascimento.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@Cep", aluno.Cep);
                comando.Parameters.AddWithValue("@Endereco", aluno.Endereco);
                comando.Parameters.AddWithValue("@Numero", aluno.Numero);
                comando.Parameters.AddWithValue("@Bairro", aluno.Bairro);
                comando.Parameters.AddWithValue("@Cidade", aluno.Cidade);
                comando.Parameters.AddWithValue("@Estado", aluno.Estado);
                comando.Parameters.AddWithValue("@Nota1", aluno.Nota1);
                comando.Parameters.AddWithValue("@Nota2", aluno.Nota2);

                if (comando.ExecuteNonQuery() > 0)
                {
                    return "Aluno inserido com sucesso!";
                }
                else
                {
                    return "Não foi possivel inserir Aluno!";
                }
            }
            catch (Exception ex)
            {
                return "Erro ao inserir Aluno: " + ex.Message;
            }
        }

        public List<Aluno> BuscarAlunos()
        {
            try
            {
                string sql = "select Nome, Idade, Cpf from Alunos";
                SqlCommand comando = new SqlCommand(sql, _conn);

                List<Aluno> alunos = new List<Aluno>();

                using (var reader = comando.ExecuteReader())
                {
                    //cria um leitor do ADO.net

                    while (reader.Read())
                    {///vai lendo cada item do resultado do select
                     ///retorna cada item encontrado
                        var nomeDb = reader.GetString(reader.GetOrdinal("Nome"));
                        var idadeDb = reader.GetInt32(reader.GetOrdinal("Idade"));
                        var cpfDb = reader.GetString(reader.GetOrdinal("Cpf"));

                        alunos.Add(new Aluno()
                        {
                            Nome = nomeDb,
                            Idade = idadeDb,
                            Cpf = cpfDb
                        });

                    }
                    return alunos;
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public string AlterarAluno(Aluno aluno)
        {
            try
            {
                string sql =
                    """
                    UPDATE Alunos 
                    SET 
                    Nome = @Nome,
                    Idade = @Idade,
                    Cpf = @Cpf
                    WHERE Cpf = @Cpf;
                    """;
                SqlCommand comando = new SqlCommand(sql, _conn);
                comando.Parameters.AddWithValue("@Nome", aluno.Nome);
                comando.Parameters.AddWithValue("@Idade", aluno.Idade);
                comando.Parameters.AddWithValue("@Cpf", aluno.Cpf);

                if (comando.ExecuteNonQuery() > 0)
                {
                    return "Dados do aluno alterados com sucesso!";
                }
                else
                {
                    return "Não foi possível alterar os dados do aluno.";
                }

            }
            catch (Exception ex)
            {
                return "Erro ao alterar Aluno: " + ex.Message;
            }
        }

        public string ExcluirAluno(string Cpf)
        {

            try
            {
                string sql =
                    """
                    DELETE FROM Alunos 
                    WHERE Cpf = @Cpf;
                    """;
                SqlCommand comando = new SqlCommand(sql, _conn);
                comando.Parameters.AddWithValue("@Cpf", Cpf);
                if (comando.ExecuteNonQuery() > 0)
                {
                    return "Aluno excluído com sucesso!";
                }
                else
                {
                    return "Não foi possível excluir o aluno.";
                }
            }
            catch (Exception ex)
            {
                return "Erro ao excluir Aluno: " + ex.Message;
            }
        }
    }
}

