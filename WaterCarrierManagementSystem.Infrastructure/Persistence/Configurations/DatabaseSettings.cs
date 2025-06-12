namespace WaterCarrierManagementSystem.Infrastructure.Persistence.Configurations;

public record DatabaseSettings
{
    public DatabaseSettings() { }

    public string DB_HOST     { get; set; } 
    public int DB_PORT        { get; set; } 
    public string DB_NAME     { get; set; } 
    public string DB_USER     { get; set; } 
    public string DB_PASSWORD { get; set; } 

    public string ConnectionString =>
        $"Server={DB_HOST};" +
        $"Port={DB_PORT};" +
        $"Database={DB_NAME};" +
        $"Uid={DB_USER};" +
        $"Pwd={DB_PASSWORD};" +
        $"CharSet=utf8;TreatTinyAsBoolean=false";

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


    public static DatabaseSettings Create(DatabaseSettings obj) =>
            new(obj.DB_HOST, obj.DB_PORT, obj.DB_NAME, obj.DB_USER, obj.DB_PASSWORD);
}

