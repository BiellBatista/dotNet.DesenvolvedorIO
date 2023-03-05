namespace DesignPatterns._01_Creational._02_Factory_Method;

// Concrete Creator
public class SqlFactory : DbFactory
{
    // Factory Method
    public override DbConnector CreateConnector(string connectionString)
    {
        return new SqlServerConnector(connectionString);
    }
}