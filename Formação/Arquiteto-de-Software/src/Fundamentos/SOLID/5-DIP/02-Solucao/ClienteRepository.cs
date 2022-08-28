using SOLID._5_DIP._02_Solucao.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace SOLID._5_DIP._02_Solucao;

internal class ClienteRepository : IClienteRepository
{
    public void AdicionarCliente(Cliente cliente)
    {
        using (var cn = new SqlConnection())
        {
            var cmd = new SqlCommand();

            cn.ConnectionString = "MinhaConnectionString";
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO CLIENTE (NOME, EMAIL CPF, DATACADASTRO) VALUES (@nome, @email, @cpf, @dataCad))";

            cmd.Parameters.AddWithValue("nome", cliente.Nome);
            cmd.Parameters.AddWithValue("email", cliente.Email);
            cmd.Parameters.AddWithValue("cpf", cliente.CPF);
            cmd.Parameters.AddWithValue("dataCad", cliente.DataCadastro);

            cn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}