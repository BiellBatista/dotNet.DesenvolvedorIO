using NerdStore.Core.Messages;

namespace NerdStore.Core;

public interface IMediatRHandler
{
    Task PublicarEvento<T>(T evento) where T : Event;
}