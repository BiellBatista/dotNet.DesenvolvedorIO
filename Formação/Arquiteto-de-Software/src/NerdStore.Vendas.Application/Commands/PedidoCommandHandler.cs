using MediatR;
using NerdStore.Core.Communication.MediatR;
using NerdStore.Core.DomainObjects.DTO;
using NerdStore.Core.Extensions;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using NerdStore.Vendas.Application.Events;
using NerdStore.Vendas.Domain;

namespace NerdStore.Vendas.Application.Commands;

public sealed class PedidoCommandHandler :
    IRequestHandler<AdicionarItemPedidoCommand, bool>,
    IRequestHandler<CancelarProcessamentoPedidoCommand, bool>,
    IRequestHandler<CancelarProcessamentoPedidoEstornarEstoqueCommand, bool>,
    IRequestHandler<FinalizarPedidoCommand, bool>
{
    private readonly IMediatRHandler _mediatRHandler;
    private readonly IPedidoRepository _pedidoRepository;

    public PedidoCommandHandler(IMediatRHandler mediatRHandler, IPedidoRepository pedidoRepository) =>
        (_mediatRHandler, _pedidoRepository) = (mediatRHandler, pedidoRepository);

    public async Task<bool> Handle(AdicionarItemPedidoCommand message, CancellationToken cancellationToken)
    {
        if (!ValidarComando(message)) return false;

        var pedido = await _pedidoRepository.ObterPedidoRascunhoPorClienteId(message.ClienteId);
        var pedidoItem = new PedidoItem(message.ProdutoId, message.Nome, message.Quantidade, message.ValorUnitario);

        if (pedido is null)
        {
            pedido = Pedido.PedidoFactory.NovoPedidoRascunho(message.ClienteId);
            pedido.AdicionarItem(pedidoItem);

            _pedidoRepository.Adicionar(pedido);

            pedido.AdicionarEvento(new PedidoRascunhoIniciadoEvent(message.ClienteId, message.ProdutoId));
        }
        else
        {
            var pedidoItemExistente = pedido.PedidoItemExistente(pedidoItem);

            pedido.AdicionarItem(pedidoItem);

            if (pedidoItemExistente)
                _pedidoRepository.AtualizarItem(pedido.PedidoItems.FirstOrDefault(p => p.ProdutoId == pedidoItem.ProdutoId));
            else _pedidoRepository.AdicionarItem(pedidoItem);
        }

        pedido.AdicionarEvento(new PedidoItemAdicionadoEvent(pedido.ClienteId, pedido.Id, message.ProdutoId, message.Nome, message.ValorUnitario, message.Quantidade));

        return await _pedidoRepository.UnitOfWork.Commit();
    }

    public async Task<bool> Handle(CancelarProcessamentoPedidoCommand message, CancellationToken cancellationToken)
    {
        var pedido = await _pedidoRepository.ObterPorId(message.PedidoId);

        if (pedido is null)
        {
            await _mediatRHandler.PublicarNotificacao(new DomainNotification("pedido", "Pedido não encontrado!"));

            return false;
        }

        pedido.TornarRascunho();

        return await _pedidoRepository.UnitOfWork.Commit();
    }

    public async Task<bool> Handle(CancelarProcessamentoPedidoEstornarEstoqueCommand message, CancellationToken cancellationToken)
    {
        var pedido = await _pedidoRepository.ObterPorId(message.PedidoId);

        if (pedido is null)
        {
            await _mediatRHandler.PublicarNotificacao(new DomainNotification("pedido", "Pedido não encontrado!"));

            return false;
        }

        var itensList = new List<Item>();

        pedido.PedidoItems.ForEach(i => itensList.Add(new Item { Id = i.ProdutoId, Quantidade = i.Quantidade }));

        var listaProdutosPedido = new ListaProdutosPedido { PedidoId = pedido.Id, Itens = itensList };

        pedido.AdicionarEvento(new PedidoProcessamentoCanceladoEvent(pedido.Id, pedido.ClienteId, listaProdutosPedido));
        pedido.TornarRascunho();

        return await _pedidoRepository.UnitOfWork.Commit();
    }

    public async Task<bool> Handle(FinalizarPedidoCommand message, CancellationToken cancellationToken)
    {
        var pedido = await _pedidoRepository.ObterPorId(message.PedidoId);

        if (pedido is null)
        {
            await _mediatRHandler.PublicarNotificacao(new DomainNotification("pedido", "Pedido não encontrado!"));

            return false;
        }

        pedido.FinalizarPedido();
        pedido.AdicionarEvento(new PedidoFinalizadoEvent(message.PedidoId));

        return await _pedidoRepository.UnitOfWork.Commit();
    }

    private bool ValidarComando(Command message)
    {
        if (message.IsValid()) return true;

        foreach (var error in message.ValidationResult.Errors)
            _mediatRHandler.PublicarNotificacao(new DomainNotification(message.MessageType, error.ErrorMessage));

        return false;
    }
}