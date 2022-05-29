using MediatR;
using NerdStore.Core.Communication;
using NerdStore.Core.Messages;

namespace NerdStore.Vendas.Application.Commands;

public class PedidoCommandHandler :
    IRequestHandler<AdicionarItemPedidoCommand, bool>
{
    private readonly IMediatRHandler _mediatorHandler;

    public async Task<bool> Handle(AdicionarItemPedidoCommand message, CancellationToken cancellationToken)
    {
        if (!ValidarComando(message)) return false;
    }

    private bool ValidarComando(Command message)
    {
        if (message.IsValid()) return true;

        foreach (var error in message.ValidationResult.Errors)
        {
            _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, error.ErrorMessage));
        }

        return false;
    }
}