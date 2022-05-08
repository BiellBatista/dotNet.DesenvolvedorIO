namespace NerdStore.Catalogo.Domain;

/// <summary>
/// Esta classe (serviço de domínio) é utilizada para realizar os processos de negócio e geralmente ela usa duas ou mais entidades.
/// Classes de serviço de domínio deve ser aprovado pelo Expert do Domínio
/// </summary>
public class EstoqueService : IEstoqueService
{
    private readonly IProdutoRepository _produtoRepository;

    public EstoqueService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
    {
        var produto = await _produtoRepository.ObterPorId(produtoId);

        if (produto == null) return false;

        if (!produto.PossuiEstoque(quantidade)) return false;

        produto.DebitarEstoque(quantidade);

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