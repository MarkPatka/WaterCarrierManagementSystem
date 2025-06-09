namespace WaterCarrierManagementSystem.Infrastructure.Persistence.Configurations;
public record DatabaseSettings
{
    public string DB_HOST     { get; init; } 
    public int DB_PORT        { get; init; } 
    public string DB_NAME     { get; init; } 
    public string DB_USER     { get; init; } 
    public string DB_PASSWORD { get; init; } 

    public string ConnectionString =>
        $"Server={DB_HOST};" +
        $"Port={DB_PORT};" +
        $"Database={DB_NAME};" +
        $"Uid={DB_USER};" +
        $"Pwd={DB_PASSWORD}";

    private DatabaseSettings(
        string host,
        int port,
        string name,
        string user,
        string password)
    {
        DB_HOST = host;
        DB_PORT = port;
        DB_NAME = name;
        DB_USER = user;
        DB_PASSWORD = password;
    }

    public static DatabaseSettings Create(
        string host, int port, string name, string user, string password) =>
            new(host, port, name, user, password);
}

