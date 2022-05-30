using MediatR;
using NerdStore.Catalogo.Application.Services;
using NerdStore.Catalogo.Data;
using NerdStore.Catalogo.Data.Repository;
using NerdStore.Catalogo.Domain;
using NerdStore.Catalogo.Domain.Events;
using NerdStore.Core.Communication.MediatR;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using NerdStore.Vendas.Application.Commands;
using NerdStore.Vendas.Data;
using NerdStore.Vendas.Data.Repository;
using NerdStore.Vendas.Domain;

namespace NerdStore.WebApp.MVC.Setup;

internal static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services)
    {
        // Mediator
        services.AddScoped<IMediatRHandler, MediatRHandler>();

        // Notifications
        services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

        // Catalogo
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IProdutoAppService, ProdutoAppService>();
        services.AddScoped<IEstoqueService, EstoqueService>();
        services.AddScoped<CatalogoContext>();

        services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();

        // Vendas
        services.AddScoped<IPedidoRepository, PedidoRepository>();
        services.AddScoped<VendasContext>();

        services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
    }
}