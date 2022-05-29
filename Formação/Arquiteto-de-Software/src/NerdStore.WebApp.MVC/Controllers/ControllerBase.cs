using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Communication;

namespace NerdStore.WebApp.MVC.Controllers;

public abstract class ControllerBase : Controller
{
    private readonly IMediatRHandler _mediatRHandler;

    protected Guid ClienteId = Guid.Parse("7c0e3bc3-7937-4202-8832-b2bd59c3637d");

    protected ControllerBase(IMediatRHandler mediatRHandler)
    {
        _mediatRHandler = mediatRHandler;
    }
}