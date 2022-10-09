using DependencyInjection.Cases;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers;

public class GenericController : Controller
{
    private readonly IGenericRepository<Cliente> _clienteRepository;

    public GenericController(IGenericRepository<Cliente> clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public void Index()
    {
        _clienteRepository.Adicionar(new Cliente());
    }
}