using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.Services;
using NerdStore.Core.Communication.MediatR;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using NerdStore.Vendas.Application.Commands;

namespace NerdStore.WebApp.MVC.Controllers;

internal sealed class CarrinhoController : ControllerBase
{
    private readonly IMediatRHandler _mediatRHandler;
    private readonly IProdutoAppService _produtoAppService;

    public CarrinhoController(
            IMediatRHandler mediatRHandler,
            INotificationHandler<DomainNotification> notifications,
            IProdutoAppService produtoAppService) : base(mediatRHandler, notifications)
    {
        _mediatRHandler = mediatRHandler;
        _produtoAppService = produtoAppService;
    }

    public IActionResult Index() => View();

    [HttpPost]
    [Route("meu-carrinho")]
    public async Task<IActionResult> AdicionarItem(Guid id, int quantidade)
    {
        var produto = await _produtoAppService.ObterPorId(id);

        if (produto == null) return BadRequest();

        if (produto.QuantidadeEstoque < quantidade)
        {
            TempData["Erro"] = "Produto com estoque insuficiente";

            return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
        }

        var command = new AdicionarItemPedidoCommand(ClienteId, produto.Id, produto.Nome, quantidade, produto.Valor);

        await _mediatRHandler.EnviarComando(command);

        if (OperacaoValida()) RedirectToAction("Index");

        TempData["Erros"] = "Produto Indisponivel";

        return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
    }
}