using NerdStore.Catalogo.Domain.Events;
using NerdStore.Core.Communication;

namespace NerdStore.Catalogo.Domain;

/// <summary>
/// Esta classe (serviço de domínio) é utilizada para realizar os processos de negócio e geralmente ela usa duas ou mais entidades.
/// Classes de serviço de domínio deve ser aprovado pelo Expert do Domínio
/// </summary>
public class EstoqueService : IEstoqueService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMediatRHandler _bus;

    public EstoqueService(IProdutoRepository produtoRepository, IMediatRHandler bus)
    {
        _produtoRepository = produtoRepository;
        _bus = bus;
    }

    public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
    {
        var produto = await _produtoRepository.ObterPorId(produtoId);

        if (produto == null) return false;

        if (!produto.PossuiEstoque(quantidade)) return false;

        produto.DebitarEstoque(quantidade);

        if (produto.QuantidadeEstoque < 10) await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.QuantidadeEstoque));

        _produtoRepository.Atualizar(produto);

        return await _produtoRepository.UnitOfWork.Commit();
    }

    public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
    {
        var produto = await _produtoRepository.ObterPorId(produtoId);

        if (produto == null) return false;

        produto.ReporEstoque(quantidade);

        _produtoRepository.Atualizar(produto);

        return await _produtoRepository.UnitOfWork.Commit();
    }

    public void Dispose() => _produtoRepository.Dispose();
}