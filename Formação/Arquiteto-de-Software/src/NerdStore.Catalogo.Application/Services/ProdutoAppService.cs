using AutoMapper;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Application.Services;

public sealed class ProdutoAppService : IProdutoAppService
{
    private readonly IEstoqueService _estoqueService;
    private readonly IMapper _mapper;
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoAppService(IEstoqueService estoqueService,
                             IMapper mapper,
                             IProdutoRepository produtoRepository) =>
        (_estoqueService, _mapper, _produtoRepository) = (estoqueService, mapper, produtoRepository);

    public async Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo) =>
        _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterPorCategoria(codigo));

    public async Task<ProdutoViewModel> ObterPorId(Guid id) =>
        _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));

    public async Task<IEnumerable<ProdutoViewModel>> ObterTodos() =>
        _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterTodos());

    public async Task<IEnumerable<CategoriaViewModel>> ObterCategorias() =>
        _mapper.Map<IEnumerable<CategoriaViewModel>>(await _produtoRepository.ObterCategorias());

    public async Task AdicionarProduto(ProdutoViewModel produtoViewModel)
    {
        var produto = _mapper.Map<Produto>(produtoViewModel);

        _produtoRepository.Adicionar(produto);

        await _produtoRepository.UnitOfWork.Commit();
    }

    public async Task AtualizarProduto(ProdutoViewModel produtoViewModel)
    {
        var produto = _mapper.Map<Produto>(produtoViewModel);

        _produtoRepository.Atualizar(produto);

        await _produtoRepository.UnitOfWork.Commit();
    }

    public async Task<ProdutoViewModel> DebitarEstoque(Guid id, int quantidade)
    {
        if (!_estoqueService.DebitarEstoque(id, quantidade).Result) throw new DomainException("Falha ao debitar estoque");

        return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));
    }

    public async Task<ProdutoViewModel> ReporEstoque(Guid id, int quantidade)
    {
        if (!_estoqueService.ReporEstoque(id, quantidade).Result) throw new DomainException("Falha ao repor estoque");

        return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));
    }

    public void Dispose()
    {
        _produtoRepository?.Dispose();
        _estoqueService?.Dispose();
    }
}