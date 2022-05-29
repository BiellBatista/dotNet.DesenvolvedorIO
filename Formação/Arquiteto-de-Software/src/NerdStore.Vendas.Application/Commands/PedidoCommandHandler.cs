using MediatR;
using NerdStore.Core.Communication;
using NerdStore.Core.Messages;
using NerdStore.Vendas.Domain;

namespace NerdStore.Vendas.Application.Commands;

public sealed class PedidoCommandHandler :
    IRequestHandler<AdicionarItemPedidoCommand, bool>
{
    private readonly IMediatRHandler _mediatoRHandler;
    private readonly IPedidoRepository _pedidoRepository;

    public PedidoCommandHandler(IMediatRHandler mediatoRHandler, IPedidoRepository pedidoRepository) =>
        (_mediatoRHandler, _pedidoRepository) = (mediatoRHandler, pedidoRepository);

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
            {
                _pedidoRepository.AtualizarItem(pedido.PedidoItems.FirstOrDefault(p => p.ProdutoId == pedidoItem.ProdutoId));
            }
            else
            {
                _pedidoRepository.AdicionarItem(pedidoItem);
            }
        }

        pedido.AdicionarEvento(new PedidoItemAdicionadoEvent(pedido.ClienteId, pedido.Id, message.ProdutoId, message.Nome, message.ValorUnitario, message.Quantidade));

        return await _pedidoRepository.UnitOfWork.Commit();
    }

    private bool ValidarComando(Command message)
    {
        if (message.IsValid()) return true;

        foreach (var error in message.ValidationResult.Errors)
        {
            _mediatoRHandler.PublicarNotificacao(new DomainNotification(message.MessageType, error.ErrorMessage));
        }

        return false;
    }
}