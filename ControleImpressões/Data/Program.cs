using Escola.Data;

// Corrigindo os erros de sintaxe e inicialização
Conexao db = new Conexao();
db.Conectar();

AlunoRepositorio alunoRepositorio = new AlunoRepositorio(db.conn);

int opcoes = 0;

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
            BuscarAluno();
            break;

        case 3:
            AlterarAluno();
            break;

        case 4:
            ExcluirAluno();
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
{  Aluno aluno = new Aluno();

        Console.WriteLine("Preencha os dados solicitados do Aluno");

        Console.WriteLine("Nome Completo");
        aluno.Nome = Console.ReadLine();

        Console.WriteLine("Idade");
        aluno.Idade = int.Parse(Console.ReadLine());

        Console.WriteLine("Cpf");
        aluno.Cpf = Console.ReadLine();

        // Adicionando as linhas para coletar os dados de endereço
        Console.WriteLine("Cep");
        aluno.Cep = Console.ReadLine();

        Console.WriteLine("Endereco");
        aluno.Endereco = Console.ReadLine();

        Console.WriteLine("Numero");
        aluno.Numero = Console.ReadLine();

        Console.WriteLine("Bairro");
        aluno.Bairro = Console.ReadLine();

        Console.WriteLine("Cidade");
        aluno.Cidade = Console.ReadLine();

        Console.WriteLine("Estado");
        aluno.Estado = Console.ReadLine();

        alunoRepositorio.InserirAluno(aluno);

    string resultado = alunoRepositorio.InserirAluno(aluno); // Corrigindo a chamada do método
    Console.WriteLine(resultado);
    Console.WriteLine("\nPressione qualquer tecla para continuar");
    Console.ReadKey();
}


void BuscarAluno()
{
    Aluno aluno = new Aluno();

    Console.WriteLine("Informe o nome do aluno que deseja buscar");
    string NomeParaBuscar= Console.ReadLine();

    var alunos = alunoRepositorio.BuscarAlunos();

    Aluno alunoEncontrado = alunos.FirstOrDefault(x => x.Nome.Equals(NomeParaBuscar, StringComparison.OrdinalIgnoreCase));

    if (alunoEncontrado != null)

        if (alunoEncontrado != null)
    {
        Console.WriteLine($"Dados de {alunoEncontrado.Nome}");
        Console.WriteLine($"Idade {alunoEncontrado.Idade}");
        Console.WriteLine($"Cpf {alunoEncontrado.Cpf}");
    }
    else
    {
        Console.WriteLine("Aluno não encontrado!");
    }
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
}

void AlterarAluno()
{
    Console.WriteLine("Informe o CPF do aluno que deseja alterar: ");
    string NomeParaAlterar = Console.ReadLine();

    var alunos = alunoRepositorio.BuscarAlunos();
    Aluno alunoEncontrado = alunos.FirstOrDefault(x => x.Cpf.Equals(NomeParaAlterar, StringComparison.OrdinalIgnoreCase));

    if (alunoEncontrado != null)
    {
        Console.WriteLine($"Dados de {alunoEncontrado.Nome}");
        Console.WriteLine($"Idade {alunoEncontrado.Idade}");
        Console.WriteLine($"Cpf {alunoEncontrado.Cpf}");

        Console.WriteLine("Informe os novos dados do aluno:");
        Console.WriteLine("Nome Completo");
        alunoEncontrado.Nome = Console.ReadLine();
        Console.WriteLine("Idade");
        alunoEncontrado.Idade = int.Parse(Console.ReadLine());
        Console.WriteLine("Cpf");
        alunoEncontrado.Cpf = Console.ReadLine();

        string resultado = alunoRepositorio.AlterarAluno(alunoEncontrado);
        Console.WriteLine(resultado);

    }
    else
    {
        Console.WriteLine("Aluno não encontrado!");
    }
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();

}

void ExcluirAluno(){
    Console.WriteLine("Informe o CPF do aluno que deseja excluir: ");
string NomeParaExcluir = Console.ReadLine();
var alunos = alunoRepositorio.BuscarAlunos();
Aluno alunoEncontrado = alunos.FirstOrDefault(x => x.Cpf.Equals(NomeParaExcluir, StringComparison.OrdinalIgnoreCase));
if (alunoEncontrado != null)
{
    Console.WriteLine($"Dados de {alunoEncontrado.Nome}");
    Console.WriteLine($"Idade {alunoEncontrado.Idade}");
    Console.WriteLine($"Cpf {alunoEncontrado.Cpf}");
    Console.WriteLine("Tem certeza que deseja excluir este aluno? (S/N)");
    string confirmacao = Console.ReadLine();
    if (confirmacao.Equals("S", StringComparison.OrdinalIgnoreCase))
    {
        string resultado = alunoRepositorio.ExcluirAluno(alunoEncontrado.Cpf);
        Console.WriteLine(resultado);
    }
    else
    {
        Console.WriteLine("Operação de exclusão cancelada.");
    }
}
else
{
    Console.WriteLine("Aluno não encontrado!");
}
Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
Console.ReadKey();
}
