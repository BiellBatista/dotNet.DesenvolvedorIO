namespace SOLID._5_DIP._01_Violacao;

internal class ClienteService
{
    public string AdicionarCliente(Cliente cliente)
    {
        if (!cliente.IsValid())
            return "Dados inválidos";

        var repo = new ClienteRepository();
        repo.AdicionarCliente(cliente);

        EmailServices.Enviar("empresa@empresa.com", cliente.Email, "Bem Vindo", "Parabéns está Cadastrado");

        return "Cliente cadastrado com sucesso";
    }
}