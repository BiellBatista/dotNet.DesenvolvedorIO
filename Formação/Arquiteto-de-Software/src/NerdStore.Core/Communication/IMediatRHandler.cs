﻿using NerdStore.Core.Messages;

namespace NerdStore.Core.Communication;

public interface IMediatRHandler
{
    Task PublicarEvento<T>(T evento) where T : Event;

    Task<bool> EnviarComando<T>(T comando) where T : Command;
}