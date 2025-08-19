using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleImpressões
{
    public class Administrativo
    {
        private List<Aluno> alunos = new List<Aluno>();

        private int contadorId = 1;

        public void CadastrarAluno()
        {
            var aluno = new Aluno();

            aluno.Id = contadorId++;
            Console.WriteLine("Nome: "); aluno.Nome = Console.ReadLine();
            Console.WriteLine("Idade: "); aluno.Idade = int.Parse(Console.ReadLine());
            Console.WriteLine("Data de Nascimento (dd/mm/aaaa)"); aluno.DataNascimento = DateTime.Parse(Console.ReadLine();
            Console.WriteLine("CPF: "); aluno.Cpf = Console.ReadLine();
            Console.WriteLine("CEP: "); aluno.Cep = Console.ReadLine();
            Console.WriteLine("Endereço: "); aluno.Endereco = Console.ReadLine();
            Console.WriteLine("Número: "); aluno.Numero = Console.ReadLine();
            Console.WriteLine("Bairro: "); aluno.Bairro = Console.ReadLine();
            Console.WriteLine("Cidade: "); aluno.Cidade = Console.ReadLine();
            Console.WriteLine("Estado: "); aluno.Estado = Console.ReadLine();

            alunos.Add(aluno);
            Console.WriteLine("Aluno cadastrado com sucesso!");
        }
        public void ConsultarAlunos()
        {
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"ID: {aluno.Id} - Nome: {aluno.Nome} - CPF:{aluno.Cpf}");
            }
        }

        public void AlterarAluno()
        {
            Console.Write("Informe o ID do aluno que deseja alterar: ");
            int id = int.Parse(Console.ReadLine());

            var aluno = alunos.FirstOrDefault(alunos => alunos.Id == id);
            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado.");
                return;
            }

            Console.WriteLine("Novo nome: ");
            aluno.Nome = Console.ReadLine();
            Console.WriteLine("Dados alterados com sucesso");
        }

        public void ExcluirAluno()
        {
            Console.Write("Informe o ID do aluno que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            var aluno = alunos.FirstOrDefault(alunos => alunos.Id == id);
            if (aluno != null)
            {
                alunos.Remove(aluno);
                Console.WriteLine("Aluno excluído.");
            }
            else
            {
                Console.WriteLine("Aluno não encontrado.");
            }
        }
        public List<Aluno> ObterAlunos()
        {
            return alunos;
        }
    }


}
