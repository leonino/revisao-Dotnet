using System.Collections;
using System;
using System.Collections.Generic;

namespace Revisao
{
  class Program
  {
    private static ConceitoEnum conceito = ConceitoEnum.E;
    private static decimal mediaGeral = 0;
    private static List<Aluno> alunos = new List<Aluno>();

    static void Main(string[] args)
    {
      int id = 0;
      string opcaoDesejada = OpcaoDesejada();

      while (opcaoDesejada.ToUpper() != "X")
      {

        switch (opcaoDesejada)
        {
          case "1":
            //Incluir aluno
            CriarAluno();
            break;
          case "2":
            //Editar aluno
            id = SelecionarAluno();
            EditarAluno(id);
            break;
          case "3":
            //Exclui aluno
            id = SelecionarAluno();
            ExcluirAluno(id);
            break;
          default:
            Console.WriteLine("Opção Invalida!!!");
            //throw new ArgumentOutOfRangeException("Opção Inválida");
            break;
        }
        Console.Clear();
        ListarAlunos();
        opcaoDesejada = OpcaoDesejada();

      }

      static string OpcaoDesejada()
      {
        Console.WriteLine();
        Console.WriteLine("Escolha a opção desejada");
        Console.WriteLine();
        Console.WriteLine("1. Inserir um aluno");
        Console.WriteLine("2. Editar aluno");
        Console.WriteLine("3. Excluir aluno");
        Console.WriteLine("X. Sair");
        Console.WriteLine();

        String opcaoDesejada = Console.ReadLine();
        Console.Clear();
        return opcaoDesejada;
      }
    }

    static void DefinirConceito()
    {
      if (mediaGeral <= 2)
        conceito = ConceitoEnum.E;
      else if (mediaGeral <= 4)
        conceito = ConceitoEnum.D;
      else if (mediaGeral <= 6)
        conceito = ConceitoEnum.C;
      else if (mediaGeral <= 8)
        conceito = ConceitoEnum.B;
      else
        conceito = ConceitoEnum.A;
    }
    static void ListarAlunos()
    {
      decimal totalGeral = 0;
      mediaGeral = 0;
      Console.WriteLine();
      Console.WriteLine("Lista de Alunos");
      Console.WriteLine("---------------------------------------------");
      Console.WriteLine(String.Format("{0,-3}", "Id") + "| " +
      String.Format("{0,-30}", "Nome") + "| " +
      String.Format("{0,-10}", "Média"));
      Console.WriteLine("---------------------------------------------");

      if (alunos.Count > 0)
      {
        for (int i = 0; i < alunos.Count; i++)
        {
          var item = alunos[i];
          Console.WriteLine(String.Format("{0:000}", i + 1) + "| " +
                String.Format("{0, -30}", item.Nome) + "| " +
                String.Format("{0:#0.0#}", item.Nota));
          totalGeral += item.Nota;
        };
        mediaGeral = Math.Round(totalGeral / alunos.Count, 1);
        DefinirConceito();
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine($"{alunos.Count} Alunos - Média geral: {mediaGeral} - Conceito: {conceito}");
      }
      else
      {
        Console.WriteLine("Nenhum Aluno adicionado");
      }
      Console.WriteLine("---------------------------------------------");
    }

    static void CriarAluno()
    {
      Console.WriteLine();
      Console.WriteLine("Informe o Nome do Aluno");
      Aluno aluno = new Aluno();
      aluno.Nome = Console.ReadLine();
      Console.WriteLine($"Informe a Nota do Aluno: {aluno.Nome}");
      if (decimal.TryParse(Console.ReadLine(), out decimal nota))
        aluno.Nota = nota;
      else
        throw new ArgumentException("O valor da Nota deve ser um decimal: 0,0 à 10,0");
      alunos.Add(aluno);

    }

    static void EditarAluno(int id)
    {
      if (id > 0 && id <= alunos.Count)
      {
        Aluno edAluno = alunos[id - 1];

        Console.WriteLine();
        Console.WriteLine($"Informe o novo Nome para: {edAluno.Nome}");
        edAluno.Nome = Console.ReadLine();
        Console.WriteLine($"Informe a nova Nota, Atual: {edAluno.Nota}");
        if (decimal.TryParse(Console.ReadLine(), out decimal ednota))
          edAluno.Nota = ednota;
        else
          throw new ArgumentException("O valor da Nota deve ser um decimal: 0,0 à 10,0");
        alunos[(id - 1)] = edAluno;
      }
    }

    static void ExcluirAluno(int id)
    {
      if (id > 0 && id <= alunos.Count)
        alunos.Remove(alunos[(id - 1)]);
      else
        Console.WriteLine("Id informado é inválido!!!");
    }

    public static int SelecionarAluno()
    {
      if (alunos.Count > 0)
      {
        ListarAlunos();
        Console.WriteLine();
        Console.WriteLine("Informe o ID do Aluno:");
        int id = int.Parse(Console.ReadLine());
        return id;
      }
      return 0;
    }
  }
}
