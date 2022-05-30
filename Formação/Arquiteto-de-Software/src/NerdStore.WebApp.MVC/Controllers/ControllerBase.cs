using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Communication.MediatR;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.WebApp.MVC.Controllers;

internal abstract class ControllerBase : Controller
{
    private readonly IMediatRHandler _mediatRHandler;

    private readonly DomainNotificationHandler _notifications;
    protected Guid ClienteId = Guid.Parse("7c0e3bc3-7937-4202-8832-b2bd59c3637d");

    protected ControllerBase(IMediatRHandler mediatRHandler, INotificationHandler<DomainNotification> notifications) =>
        (_mediatRHandler, _notifications) = (mediatRHandler, (DomainNotificationHandler)notifications);

    protected bool OperacaoValida() => !_notifications.TemNotificacao();

    protected IEnumerable<string> ObterMensagensErro() => _notifications.ObterNotificacoes().Select(c => c.Value).ToList();

    protected void NotificarErro(string codigo, string message) =>
        _mediatRHandler.PublicarNotificacao(new DomainNotification(codigo, message));
}