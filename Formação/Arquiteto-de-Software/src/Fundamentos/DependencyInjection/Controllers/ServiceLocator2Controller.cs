using DependencyInjection.Cases;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers;

public class ServiceLocator2Controller : Controller
{
    public void Index([FromServices] IServiceProvider serviceProvider)
    {
        // Retorna null se não estiver registrado
        serviceProvider.GetRequiredService<IClienteServices>().AdicionarCliente(new Cliente());
    }
}