using MediatR;
using NerdStore.Core.DomainObjects;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.Core.Communication.MediatR;

public sealed class MediatRHandler : IMediatRHandler
{
    private readonly IMediator _mediator;

    public MediatRHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<bool> EnviarComando<T>(T comando) where T : Command => await _mediator.Send(comando);

    public async Task PublicarEvento<T>(T evento) where T : Event
    {
        await _mediator.Publish(evento);
    }

    public async Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification => await _mediator.Publish(notificacao);

    public async Task PublicarDomainEvent<T>(T notificacao) where T : DomainEvent => await _mediator.Publish(notificacao);
}