using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Communication.MediatR;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using NerdStore.Vendas.Application.Queries;

namespace NerdStore.WebApp.MVC.Controllers;

public sealed class PedidoController : ControllerBase
{
    private readonly IPedidoQueries _pedidoQueries;

    public PedidoController(IPedidoQueries pedidoQueries,
        INotificationHandler<DomainNotification> notifications,
        IMediatRHandler mediatRHandler) : base(mediatRHandler, notifications)
    {
        _pedidoQueries = pedidoQueries;
    }

    [Route("meus-pedidos")]
    public async Task<IActionResult> Index() => View(await _pedidoQueries.ObterPedidosCliente(ClienteId));
}