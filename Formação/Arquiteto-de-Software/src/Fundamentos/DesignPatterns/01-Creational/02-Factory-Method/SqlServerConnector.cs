namespace DesignPatterns._01_Creational._01_Factory_Method;

// Concrete Product
public class SqlServerConnector : DbConnector
{
    public SqlServerConnector(string connectionString) : base(connectionString)
    {
        ConnectionString = connectionString;
    }

    public override Connection Connect()
    {
        Console.WriteLine("Conectando ao banco SQL Server...");
        var connection = new Connection(ConnectionString);
        connection.Open();

        return connection;
    }
}