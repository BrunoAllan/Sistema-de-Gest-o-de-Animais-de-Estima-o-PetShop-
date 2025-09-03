using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static PetShop p;
    static void Main()
    {
        p = new PetShop();

        Console.WriteLine("=== Bem-vindo ao PetShop! ===");
        Console.WriteLine("1 - Cadastrar Cachorro");
        Console.WriteLine("2 - Cadastrar Gato");
        Console.WriteLine("3 - Cadastrar Papagaio");
        Console.WriteLine("4 - Listar Animais");
        Console.WriteLine("5 - Calcular média de idade de animal");
        Console.WriteLine("0 - Sair");

        switch (Console.ReadLine())
        {
            case "1": CadastrarCachorro(); break;
            case "2": CadastrarGato(); break;
            case "3": CadastrarPapagaio(); break;
            case "4": p.ListarAnimais(); Continuar(); break;
            case "5": CalcularMedia(); break;
            case "0": Sair(); break;
            default:
                Console.WriteLine("Opção inválida");
                Continuar();
                break;
        }
    }

    static void Sair()
    {
        Console.WriteLine("Saindo...");
        Environment.Exit(0);
    }

    static void Continuar()
    {
        Console.WriteLine("Clique para continuar...");
        Console.ReadKey();
        Console.Clear();
        Main();
    }

    static void CalcularMedia()
{
    if (PetShop.Animais.Count == 0)
    {
        Console.WriteLine("Nenhum animal cadastrado!");
    }
    else
    {
        double media = PetShop.Animais.Average(a => a.Idade);
        Console.WriteLine($"Média de idade dos animais: {media:F2} anos");
    }
    Continuar();
}


    static void CadastrarCachorro()
    {
        Cachorro a = new Cachorro();
        Console.WriteLine("Digite o Nome do Cachorro:");
        a.Nome = Console.ReadLine();
        Console.WriteLine("Digite a Idade do Cachorro:");
        a.Idade = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite a Raça do Cachorro:");
        a.Raca = Console.ReadLine();
        p.AdicionarAnimal(a);
        Console.WriteLine("Cachorro cadastrado com sucesso!");
        Continuar();
    }

    static void CadastrarGato()
    {
        Gato a = new Gato();
        Console.WriteLine("Digite o Nome do Gato:");
        a.Nome = Console.ReadLine();
        Console.WriteLine("Digite a Idade do Gato:");
        a.Idade = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite a Cor do Gato:");
        a.Cor = Console.ReadLine();
        p.AdicionarAnimal(a);
        Console.WriteLine("Gato cadastrado com sucesso!");
        Continuar();
    }

    static void CadastrarPapagaio()
    {
        Papagaio a = new Papagaio();
        Console.WriteLine("Digite o Nome do Papagaio:");
        a.Nome = Console.ReadLine();
        Console.WriteLine("Digite a Idade do Papagaio:");
        a.Idade = int.Parse(Console.ReadLine());
        p.AdicionarAnimal(a);
        Console.WriteLine("Papagaio cadastrado com sucesso!");
        Continuar();
    }

    class Animal
    {
        public string Nome  { get; set; }
        public int Idade  { get; set; }

        public virtual void EmitirSom()
        {
            Console.WriteLine("Som genérico");
        }

        public virtual void ExibirInfo()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Idade: {Idade}");
        }
    }

    class Cachorro : Animal
    {
        public string Raca { get; set; }

        public override void ExibirInfo()
        {
            base.ExibirInfo();
            Console.WriteLine($"Raça: {Raca}");
        }

        public override void EmitirSom()
        {
            Console.WriteLine("Au Au");
        }
    }

    class Gato : Animal
    {
        public string Cor { get; set; }

        public override void ExibirInfo()
        {
            base.ExibirInfo();
            Console.WriteLine($"Cor: {Cor}");
        }

        public override void EmitirSom()
        {
            Console.WriteLine("Miau");
        }
    }

    class Papagaio: Animal
    {
        public override void ExibirInfo()
        {
            base.ExibirInfo();
        }

        public override void EmitirSom()
        {
            Console.WriteLine("Curupaco");
        }
    }

    class PetShop
    {
        public static List<Animal> Animais = new List<Animal>();

        public void AdicionarAnimal(Animal a)
        {
            Animais.Add(a);
        }

        public void ListarAnimais()
        {
            foreach(Animal a in Animais)
            {
                a.ExibirInfo();
                a.EmitirSom();
                Console.WriteLine();
            }
        }
    }
}