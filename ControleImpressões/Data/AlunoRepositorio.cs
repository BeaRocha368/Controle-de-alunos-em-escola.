namespace ControleImpress�es.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using ControleImpress�es;

    public class AlunoRepositorio
    {
        private SqlConnection _conn;

        public AlunoRepositorio(SqlConnection conn)
        {
            _conn = conn;
        }

        public void ConsultarNotas(List<Aluno> alunos)
        {
            Console.WriteLine("Informe seu ID");
            int id = int.Parse(Console.ReadLine());

            var aluno = alunos.FirstOrDefault(alunos => alunos.Id == id);
            if (aluno == null) {
                Console.WriteLine("Aluno n�o encontrado.");
                return;
            }
            Console.WriteLine($"Nota 1: {aluno.Nota1}");
            Console.WriteLine($"Nota 2: {aluno.Nota2}");
            Console.WriteLine($"M�dia: {aluno.Media}");
        }
    }
}