using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleImpressões
{
    public class Professor
    {
        public void CadastrarNotas(List<Aluno> alunos)
        {
            Console.WriteLine("Informe o ID do aluno para lançar notas: ");
            int id = int.Parse(Console.ReadLine());

            var aluno = alunos.FirstOrDefault(alunos => alunos.Id == id);
            if (aluno == null) {
                Console.WriteLine("Aluno não encontrado");
                return;
                    
            }
            Console.WriteLine("Nota 1: ");
            aluno.Nota1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Nota 2: ");
            aluno.Nota2 = double.Parse(Console.ReadLine());
            
            aluno.Media = (aluno.Nota1 + aluno.Nota2) / 2;
            Console.WriteLine("Notas cadastradas com sucesso!");


        }
    }
}
