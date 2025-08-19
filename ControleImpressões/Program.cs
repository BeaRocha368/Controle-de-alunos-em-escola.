using System.Data.SqlClient;
using ControleImpressões;
using ControleImpressões.Data;

Conexao db = new Conexao();
//db representa classe conexão

db.Conectar();

AlunoRepositorio alunoRepositorio = new AlunoRepositorio(db .conn);

int opcoes  = 0;

while (opcoes != 5)
{
    opcoes = Menu();
    Console.Clear();
    switch (opcoes)
    {
        case 1:
            CadastrarAluno();
            break;
        case 2:
            ConsultarAluno();
            break;
        case 3:

            break;
        case 4:

            break;
        case 5:
            Console.WriteLine("ENCERRANDO PROGRAMA....");
            break;
    }
}
Console.ReadKey();
static int Menu()
{
    Console.WriteLine("MENU DE OPÇÕES");
    Console.WriteLine("===================");
    Console.WriteLine("[1] Cadastrar Aluno");
    Console.WriteLine("[2] Consultar Aluno");
    Console.WriteLine("[3] Alterar dados do aluno");
    Console.WriteLine("[4] Excluir Aluno");
    Console.WriteLine("[5] Sair");

    int opcoes = int.Parse(Console.ReadLine());
    return opcoes;
}

void CadastrarAluno()
{
    Aluno aluno = new Aluno();

    Console.WriteLine("Preencha os dados solicitados do Aluno");

    Console.WriteLine("Nome Completo");
    aluno.Nome = Console.ReadLine();

    Console.WriteLine("Idade");
    aluno.Idade = int.Parse(Console.ReadLine());

    Console.WriteLine("Cpf");
    aluno.Cpf = Console.ReadLine();

    alunoRepositorio.InserirAluno(db, aluno);

}

void ConsultarAluno()
{
    try
    {
        var lista = alunoRepositorio.ObterTodosAlunos();

        Console.WriteLine("LISTA DE ALUNOS");
        Console.WriteLine("=======================");

        foreach (var aluno in lista)
        {
            Console.WriteLine($"Código: {aluno.Codigo} | Nome: {aluno.Nome} | Idade: {aluno.Idade} | CPF: {aluno.Cpf} ");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }
    catch (Exception ex) {

        Console.WriteLine("Erro ao consultar alunos:" + ex.Message);
    }
}