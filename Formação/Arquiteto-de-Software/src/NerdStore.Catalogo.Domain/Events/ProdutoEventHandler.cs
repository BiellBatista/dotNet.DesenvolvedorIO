using MediatR;
using NerdStore.Core.Communication.MediatR;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents;

namespace NerdStore.Catalogo.Domain.Events;

public class ProdutoEventHandler :
        INotificationHandler<ProdutoAbaixoEstoqueEvent>,
        INotificationHandler<PedidoIniciadoEvent>,
        INotificationHandler<PedidoProcessamentoCanceladoEvent>
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IEstoqueService _estoqueService;
    private readonly IMediatRHandler _mediatRHandler;

    public ProdutoEventHandler(IProdutoRepository produtoRepository, IEstoqueService estoqueService, IMediatRHandler mediatRHandler)
    {
        _produtoRepository = produtoRepository;
        _estoqueService = estoqueService;
        _mediatRHandler = mediatRHandler;
    }

    public async Task Handle(ProdutoAbaixoEstoqueEvent mensagem, CancellationToken cancellationToken)
    {
        var produto = await _produtoRepository.ObterPorId(mensagem.AggregateId);

        // Realizar alguma tarefa
    }

    public async Task Handle(PedidoIniciadoEvent message, CancellationToken cancellationToken)
    {
        var result = await _estoqueService.DebitarListaProdutosPedido(message.ProdutosPedido);

        if (result)
            await _mediatRHandler.PublicarEvento(new PedidoEstoqueConfirmadoEvent(message.PedidoId, message.ClienteId,
                message.Total, message.ProdutosPedido, message.NomeCartao, message.NumeroCartao, message.ExpiracaoCartao,
                message.CvvCartao));
        else
            await _mediatRHandler.PublicarEvento(new PedidoEstoqueRejeitadoEvent(message.PedidoId, message.ClienteId));
    }

    public async Task Handle(PedidoProcessamentoCanceladoEvent message, CancellationToken cancellationToken) =>
        await _estoqueService.ReporListaProdutosPedido(message.ProdutosPedido);
}