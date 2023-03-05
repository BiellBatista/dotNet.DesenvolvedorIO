using DesignPatterns._01_Creational._01_Abstract_Factory;
using DesignPatterns._01_Creational._02_Factory_Method;
using DesignPatterns._01_Creational._03_Singleton;
using DesignPatterns._02_Structural._01_Adapter;
using DesignPatterns._02_Structural._02_Facade;
using DesignPatterns._02_Structural._03_Composite;
using DesignPatterns._03_Behavioral._01_Command;
using DesignPatterns._03_Behavioral._02_Strategy;
using DesignPatterns._03_Behavioral._03_Observable;

namespace DesignPatterns;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Escolha a operação:");
        Console.WriteLine("------------------------");
        Console.WriteLine("Creational Patterns");
        Console.WriteLine("------------------------");
        Console.WriteLine("1 - Abstract Factory");
        Console.WriteLine("2 - Method Factory");
        Console.WriteLine("3 - Singleton");
        Console.WriteLine("------------------------");
        Console.WriteLine("Structural Patterns");
        Console.WriteLine("------------------------");
        Console.WriteLine("4 - Adapter");
        Console.WriteLine("5 - Facade");
        Console.WriteLine("6 - Composite");
        Console.WriteLine("------------------------");
        Console.WriteLine("Behavioral Patterns");
        Console.WriteLine("------------------------");
        Console.WriteLine("7 - Command");
        Console.WriteLine("8 - Strategy");
        Console.WriteLine("9 - Observer");
        Console.WriteLine("------------------------");

        var opcao = Console.ReadKey();

        Console.WriteLine("");
        Console.WriteLine("------------------------");
        Console.WriteLine("");

        switch (opcao.KeyChar)
        {
            case '1':
                ExecucaoAbstractFactory.Executar();
                break;

            case '2':
                ExecucaoFactoryMethod.Executar();
                break;

            case '3':
                ExecucaoSingleton.Executar();
                break;

            case '4':
                ExecucaoAdapter.Executar();
                break;

            case '5':
                ExecucaoFacade.Executar();
                break;

            case '6':
                ExecucaoComposite.Executar();
                break;

            case '7':
                ExecucaoCommand.Executar();
                break;

            case '8':
                ExecucaoStrategy.Executar();
                break;

            case '9':
                ExecucaoObserver.Executar();
                break;
        }

        Console.ReadKey();
        Console.Clear();
        Main();
    }
}