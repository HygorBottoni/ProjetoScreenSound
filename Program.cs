using System.ComponentModel;

// Projeto Screen Sound

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Maneva", new List<int> { 10, 8, 7 });
bandasRegistradas.Add("Ponto de equilibrio", new List<int> { 10, 5, 15, 8, 12 });

void ExibirMensagemDeBoasVindas()
{
    Console.WriteLine("");
    Console.WriteLine(@"Ｓｃｒｅｅｎ Ｓｏｕｎｄ");
    Console.WriteLine("\n### Bem vindo ao Screen Sound ###\n");
}

void ExibirMenu()
{
    Console.WriteLine("### MENU INICIAL ###\n1 - Registrar uma banda\n2 - Mostrar todas as bandas\n3 - Avaliar uma banda\n4 - Exibir média da banda\n0 - Sair\n");
    Console.Write("Digite alguma das opções abaixo para acessar a função: ");
    var respostaDoMenu = Console.ReadLine()!;
    int respostaDoMenuEmNumero = int.Parse(respostaDoMenu);

    switch (respostaDoMenuEmNumero)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            ExibirListaDeBandas();
            break;
        case 3:
            AvaliarBanda();
            break;
        case 4:
            ExibirMediaDaBanda();
            break;
        case 0:
            Console.WriteLine("Você escolheu a opção 0\n Fechando a aplicação.");
            System.Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Opção invalida!!");
            ExibirMenu();
            break;
    }
}

void RegistrarBanda()
{
    Console.WriteLine("Informe o nome da banda que você deseja cadastrar:");
    var banda = Console.ReadLine()!;
    //ListaDeBandas.Add(banda!);
    bandasRegistradas.Add(banda, new List<int>());
    Console.WriteLine($"A banda {banda} foi cadastrada com sucesso.");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirMenu();

}

void ExibirListaDeBandas()
{
    //int comprimento = ListaDeBandas.Count;

    // if (comprimento == 0)
    // {
    //     Console.WriteLine("A lista está vazia");
    // }

    // for (int i = 0; i < comprimento; i++)
    // {
    //     Console.WriteLine($"Banda {i + 1}: {ListaDeBandas[i]}");
    // }

    foreach (var bandas in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {bandas}");
    }

    Console.WriteLine("\nEssa é a lista total cadastrada.\n");
    Thread.Sleep(3000);
    ExibirMenu();

}

void AvaliarBanda()
{
    Console.WriteLine("Informe o nome da banda que você deseja avaliar");
    var bandaAvaliada = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(bandaAvaliada))
    {
        Console.Write($"A banda {bandaAvaliada} merece qual nota ? ");
        int notaDaBanda = int.Parse(Console.ReadLine()!);
        bandasRegistradas[bandaAvaliada].Add(notaDaBanda);
        Console.WriteLine($"\nVocê atribuiu a nota {notaDaBanda} para a banda {bandaAvaliada}.\n");
        Thread.Sleep(2500);
        ExibirMenu();
    }
    else
    {
        Console.WriteLine($"A banda {bandaAvaliada} não foi encontrada em nossos registros!\nVoltando ao Menu principal");
        Thread.Sleep(3000);
        ExibirMenu();
    }
}

void ExibirMediaDaBanda()
{

    Console.WriteLine("Informe o nome da banda que você deseja ver a média das notas: ");
    var respostaMediaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(respostaMediaBanda))
    {
        var somaDeNotas = bandasRegistradas[respostaMediaBanda].Sum();
        var divisor = bandasRegistradas[respostaMediaBanda].Count();
        double notaMediaBanda = somaDeNotas / divisor;

        Console.WriteLine($"A média de notas da banda {respostaMediaBanda} é {notaMediaBanda}.");
        Thread.Sleep(2500);
        ExibirMenu();
    }
    else
    {
        Console.WriteLine("A banda informada não possui registro em nosso sistema!");
        Thread.Sleep(2000);
        ExibirMenu();
    }

}

ExibirMensagemDeBoasVindas();
ExibirMenu();

