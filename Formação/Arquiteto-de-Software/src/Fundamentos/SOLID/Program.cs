using SOLID._2_OCP._02_SolucaoExtensionMethods;
using SOLID._3_LSP._01_Violacao;

namespace SOLID;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Escolha a operação");
        Console.WriteLine("1 - OCP");
        Console.WriteLine("2 - LSP");

        var opcao = Console.ReadKey();

        switch (opcao.KeyChar)
        {
            case '1':
                CaixaEletronico.Operacoes();
                break;

            case '2':
                CalculoArea.Calcular();
                break;
        }
    }
}