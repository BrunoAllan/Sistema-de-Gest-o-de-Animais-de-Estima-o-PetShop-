using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    /// <summary>
    /// Instância compartilhada do PetShop usada pelas operações do programa.
    /// </summary>
    static PetShop p;

    /// <summary>
    /// Ponto de entrada da aplicação. Mostra o menu e direciona para as ações.
    /// </summary>
    /// <remarks>
    /// O método chama <see cref="Main"/> novamente após cada operação via <see cref="Continuar"/>,
    /// funcionando como um laço de navegação simples.
    /// </remarks>
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

    /// <summary>
    /// Encerra a aplicação com código de saída 0.
    /// </summary>
    static void Sair()
    {
        Console.WriteLine("Saindo...");
        Environment.Exit(0);
    }

    /// <summary>
    /// Aguarda uma tecla, limpa a tela e retorna ao menu principal.
    /// </summary>
    static void Continuar()
    {
        Console.WriteLine("Clique para continuar...");
        Console.ReadKey();
        Console.Clear();
        Main();
    }

    /// <summary>
    /// Calcula e exibe a média das idades de todos os animais cadastrados.
    /// </summary>
    /// <remarks>
    /// Caso não haja animais cadastrados, informa o usuário.
    /// </remarks>
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

    /// <summary>
    /// Fluxo de cadastro de um <see cref="Cachorro"/>.
    /// </summary>
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

    /// <summary>
    /// Fluxo de cadastro de um <see cref="Gato"/>.
    /// </summary>
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

    /// <summary>
    /// Fluxo de cadastro de um <see cref="Papagaio"/>.
    /// </summary>
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

    /// <summary>
    /// Classe base que representa um animal genérico do pet shop.
    /// </summary>
    class Animal
    {
        /// <summary>
        /// Nome do animal.
        /// </summary>
        /// <value>Texto livre representando o nome.</value>
        public string Nome { get; set; }

        /// <summary>
        /// Idade do animal em anos.
        /// </summary>
        /// <value>Inteiro maior ou igual a zero.</value>
        public int Idade { get; set; }

        /// <summary>
        /// Emite o som característico do animal.
        /// </summary>
        public virtual void EmitirSom()
        {
            Console.WriteLine("Som genérico");
        }

        /// <summary>
        /// Exibe no console as informações básicas do animal.
        /// </summary>
        public virtual void ExibirInfo()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Idade: {Idade}");
        }
    }

    /// <summary>
    /// Representa um cachorro.
    /// </summary>
    class Cachorro : Animal
    {
        /// <summary>
        /// Raça do cachorro.
        /// </summary>
        /// <value>Texto livre com a raça.</value>
        public string Raca { get; set; }

        /// <inheritdoc/>
        public override void ExibirInfo()
        {
            base.ExibirInfo();
            Console.WriteLine($"Raça: {Raca}");
        }

        /// <inheritdoc/>
        public override void EmitirSom()
        {
            Console.WriteLine("Au Au");
        }
    }

    /// <summary>
    /// Representa um gato.
    /// </summary>
    class Gato : Animal
    {
        /// <summary>
        /// Cor predominante do gato.
        /// </summary>
        /// <value>Texto livre com a cor.</value>
        public string Cor { get; set; }

        /// <inheritdoc/>
        public override void ExibirInfo()
        {
            base.ExibirInfo();
            Console.WriteLine($"Cor: {Cor}");
        }

        /// <inheritdoc/>
        public override void EmitirSom()
        {
            Console.WriteLine("Miau");
        }
    }

    /// <summary>
    /// Representa um papagaio.
    /// </summary>
    class Papagaio : Animal
    {
        /// <inheritdoc/>
        public override void ExibirInfo()
        {
            base.ExibirInfo();
        }

        /// <inheritdoc/>
        public override void EmitirSom()
        {
            Console.WriteLine("Curupaco");
        }
    }

    /// <summary>
    /// Responsável por armazenar e operar sobre a lista de animais do pet shop.
    /// </summary>
    class PetShop
    {
        /// <summary>
        /// Lista estática de animais cadastrados.
        /// </summary>
        /// <remarks>
        /// É estática para ser facilmente acessível em diferentes métodos do programa.
        /// </remarks>
        public static List<Animal> Animais = new List<Animal>();

        /// <summary>
        /// Adiciona um novo animal à lista.
        /// </summary>
        /// <param name="a">Instância do animal a ser adicionada.</param>
        public void AdicionarAnimal(Animal a)
        {
            Animais.Add(a);
        }

        /// <summary>
        /// Lista todos os animais cadastrados, exibindo suas informações e sons.
        /// </summary>
        public void ListarAnimais()
        {
            foreach (Animal a in Animais)
            {
                a.ExibirInfo();
                a.EmitirSom();
                Console.WriteLine();
            }
        }
    }
}
