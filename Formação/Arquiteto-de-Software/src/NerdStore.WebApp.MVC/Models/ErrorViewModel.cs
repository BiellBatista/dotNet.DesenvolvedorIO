namespace NerdStore.WebApp.MVC.Models;

internal sealed class ErrorViewModel
{
    public string RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}