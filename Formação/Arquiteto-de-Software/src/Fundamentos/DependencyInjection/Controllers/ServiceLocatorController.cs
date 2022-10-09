using DependencyInjection.Cases;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers;

public class ServiceLocatorController : Controller
{
    private readonly IServiceProvider _serviceProvider;

    public ServiceLocatorController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Index()
    {
        // Retorna null se não estiver registrado
        _serviceProvider.GetRequiredService<IClienteServices>().AdicionarCliente(new Cliente());
    }
}