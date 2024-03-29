﻿using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.Data;

namespace NerdStore.Catalogo.Data.Repository;

public sealed class ProdutoRepository : IProdutoRepository
{
    private readonly CatalogoContext _context;

    public ProdutoRepository(CatalogoContext context) => (_context) = (context);

    public IUnitOfWork UnitOfWork => _context;

    //O AsNoTracking diminui o conusmo do EntityFramework
    public async Task<IEnumerable<Produto>> ObterTodos() =>
        await _context.Produtos.AsNoTracking().ToListAsync();

    //O AsNoTracking diminui o conusmo do EntityFramework
    public async Task<Produto> ObterPorId(Guid id) =>
        await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

    //O AsNoTracking diminui o conusmo do EntityFramework
    public async Task<IEnumerable<Produto>> ObterPorCategoria(int codigo) =>
        await _context.Produtos.AsNoTracking().Include(p => p.Categoria).Where(c => c.Categoria.Codigo == codigo).ToListAsync();

    //O AsNoTracking diminui o conusmo do EntityFramework
    public async Task<IEnumerable<Categoria>> ObterCategorias() =>
        await _context.Categorias.AsNoTracking().ToListAsync();

    public void Adicionar(Produto produto) => _context.Produtos.Add(produto);

    public void Atualizar(Produto produto) => _context.Produtos.Update(produto);

    public void Adicionar(Categoria categoria) => _context.Categorias.Add(categoria);

    public void Atualizar(Categoria categoria) => _context.Categorias.Update(categoria);

    public void Dispose() => _context?.Dispose();
}