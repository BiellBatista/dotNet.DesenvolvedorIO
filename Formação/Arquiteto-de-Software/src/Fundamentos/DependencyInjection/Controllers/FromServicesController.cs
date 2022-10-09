using DependencyInjection.Cases;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers;

public class FromServicesController : Controller
{
    public void Index([FromServices] IClienteServices clienteServices)
    {
        clienteServices.AdicionarCliente(new Cliente());
    }
}