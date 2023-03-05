namespace DesignPatterns._01_Creational._01_Factory_Method;

// Concrete Product
public class OracleDbConnector : DbConnector
{
    public OracleDbConnector(string connectionString) : base(connectionString)
    {
        ConnectionString = connectionString;
    }

    public override Connection Connect()
    {
        Console.WriteLine("Conectando ao banco Oracle...");
        var connection = new Connection(ConnectionString);
        connection.Open();

        return connection;
    }
}