namespace DesignPatterns._01_Creational._01_Factory_Method;

// Abstract Product
public abstract class DbConnector
{
    protected DbConnector(string connectionString)
    {
        ConnectionString = connectionString;
    }

    protected string ConnectionString { get; set; }

    public abstract Connection Connect();
}