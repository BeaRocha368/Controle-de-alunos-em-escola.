using System.Data.SqlClient;
using ControleImpressões;

Conexao db = new Conexao();
//db representa classe conexão

db.Conectar();

List<Aluno> alunos = new List<Aluno>();

alunos.Add(new Aluno { Nome = "Ana", Idade= 36, Cpf= "019.197.262-25"});
alunos.Add(new Aluno { Nome = "Thiago", Idade = 42, Cpf = "000.540.098-40" });

foreach (var aluno in alunos)
{
    var retorno = InserirAluno(db, aluno);
    Console.WriteLine(retorno);
}

static string InserirAluno(Conexao db, Aluno aluno)
{
    try
    {
        string sql = $"INSERT INTO Aluno(Nome, Idade, Cpf) VALUES('{aluno.Nome}', {aluno.Idade}, '{aluno.Cpf}')";
        SqlCommand comando = new SqlCommand(sql, db.conn);

        comando.ExecuteNonQuery();

        return "Aluno inserido com sucesso";
    }
    catch(Exception e)  
    {
        return "Erro ao inserir aluno";
    }
}