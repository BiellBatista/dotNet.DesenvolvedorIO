namespace SOLID._1_SRP._02_Solucao;

internal class Cliente
{
    public int ClienteId { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string CPF { get; set; }
    public DateTime DataCadastro { get; set; }

    public bool IsValid()
    {
        return EmailServices.IsValid(Email) && CPFServices.IsValid(CPF);
    }
}