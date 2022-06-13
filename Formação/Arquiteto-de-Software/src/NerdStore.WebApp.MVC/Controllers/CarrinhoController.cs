using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.Services;
using NerdStore.Core.Communication.MediatR;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using NerdStore.Vendas.Application.Commands;
using NerdStore.Vendas.Application.Queries;

namespace NerdStore.WebApp.MVC.Controllers;

internal sealed class CarrinhoController : ControllerBase
{
    private readonly IMediatRHandler _mediatRHandler;
    private readonly IPedidoQueries _pedidoQueries;
    private readonly IProdutoAppService _produtoAppService;

    public CarrinhoController(
            IMediatRHandler mediatRHandler,
            INotificationHandler<DomainNotification> notifications,
            IPedidoQueries pedidoQueries,
            IProdutoAppService produtoAppService) : base(mediatRHandler, notifications)
    {
        _mediatRHandler = mediatRHandler;
        _pedidoQueries = pedidoQueries;
        _produtoAppService = produtoAppService;
    }

    [Route("meu-carrinho")]
    public async Task<IActionResult> IndexAsync() => View(await _pedidoQueries.ObterCarrinhoCliente(ClienteId));

    [HttpPost]
    [Route("meu-carrinho")]
    public async Task<IActionResult> AdicionarItem(Guid id, int quantidade)
    {
        var produto = await _produtoAppService.ObterPorId(id);

        if (produto is null) return BadRequest();

        if (produto.QuantidadeEstoque < quantidade)
        {
            TempData["Erro"] = "Produto com estoque insuficiente";

            return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
        }

        var command = new AdicionarItemPedidoCommand(ClienteId, produto.Id, produto.Nome, quantidade, produto.Valor);

        await _mediatRHandler.EnviarComando(command);

        if (OperacaoValida()) RedirectToAction("Index");

        TempData["Erros"] = ObterMensagensErro();

        return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
    }

    //[HttpPost]
    //[Route("remover-item")]
    //public async Task<IActionResult> RemoverItem(Guid id)
    //{
    //    var produto = await _produtoAppService.ObterPorId(id);

    //    if (produto is null) return BadRequest();

    //    var command = new RemoverItemPedidoCommand(ClienteId, id);

    //    await _mediatRHandler.EnviarComando(command);

    //    if (OperacaoValida()) return RedirectToAction("Index");

    //    return View("Index", await _pedidoQueries.ObterCarrinhoCliente(ClienteId));
    //}

    //[HttpPost]
    //[Route("atualizar-item")]
    //public async Task<IActionResult> AtualizarItem(Guid id, int quantidade)
    //{
    //    var produto = await _produtoAppService.ObterPorId(id);

    //    if (produto is null) return BadRequest();

    //    var command = new AtualizarItemPedidoCommand(ClienteId, id, quantidade);

    //    await _mediatRHandler.EnviarComando(command);

    //    if (OperacaoValida()) return RedirectToAction("Index");

    //    return View("Index", await _pedidoQueries.ObterCarrinhoCliente(ClienteId));
    //}

    //[HttpPost]
    //[Route("aplicar-voucher")]
    //public async Task<IActionResult> AplicarVoucher(string voucherCodigo)
    //{
    //    var command = new AplicarVoucherPedidoCommand(ClienteId, voucherCodigo);

    //    await _mediatRHandler.EnviarComando(command);

    //    if (OperacaoValida()) return RedirectToAction("Index");

    //    return View("Index", await _pedidoQueries.ObterCarrinhoCliente(ClienteId));
    //}
}