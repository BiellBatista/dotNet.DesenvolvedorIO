using MediatR;
using NerdStore.Core.Communication.MediatR;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents;
using NerdStore.Vendas.Application.Commands;

namespace NerdStore.Vendas.Application.Events;

public sealed class PedidoEventHandler :
        INotificationHandler<PedidoRascunhoIniciadoEvent>,
        INotificationHandler<PedidoItemAdicionadoEvent>,
        INotificationHandler<PedidoEstoqueRejeitadoEvent>,
        INotificationHandler<PedidoPagamentoRealizadoEvent>,
        INotificationHandler<PedidoPagamentoRecusadoEvent>
{
    private readonly IMediatRHandler _mediatRHandler;

    public PedidoEventHandler(IMediatRHandler mediatRHandler) => _mediatRHandler = mediatRHandler;

    public Task Handle(PedidoRascunhoIniciadoEvent notification, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task Handle(PedidoItemAdicionadoEvent notification, CancellationToken cancellationToken) => Task.CompletedTask;

    public async Task Handle(PedidoEstoqueRejeitadoEvent message, CancellationToken cancellationToken) =>
        await _mediatRHandler.EnviarComando(new CancelarProcessamentoPedidoCommand(message.PedidoId, message.ClienteId));

    public async Task Handle(PedidoPagamentoRealizadoEvent message, CancellationToken cancellationToken) =>
        await _mediatRHandler.EnviarComando(new FinalizarPedidoCommand(message.PedidoId, message.ClienteId));

    public async Task Handle(PedidoPagamentoRecusadoEvent message, CancellationToken cancellationToken) =>
        await _mediatRHandler.EnviarComando(
            new CancelarProcessamentoPedidoEstornarEstoqueCommand(message.PedidoId, message.ClienteId));
}