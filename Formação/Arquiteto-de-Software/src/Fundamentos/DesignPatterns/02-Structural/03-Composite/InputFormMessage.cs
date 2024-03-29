﻿namespace DesignPatterns._02_Structural._03_Composite;

public class InputFormMessage : IMessage
{
    public string Nome { get; set; }

    public InputFormMessage(string name)
    {
        Nome = name;
    }

    public void ExibirMensagens(int sub)
    {
        Console.WriteLine(new string('-', sub) + Nome);
    }
}