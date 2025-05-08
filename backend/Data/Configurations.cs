namespace Backend.Data;

public static class DatabaseConfig
{
    // Using ?? to have a default value, if none has been set in the dev environment. 
    static readonly string Host = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
    static readonly int Port = int.Parse(Environment.GetEnvironmentVariable("DB_PORT") ?? "5432");
    static readonly string Database = Environment.GetEnvironmentVariable("DB_NAME") ?? "fileDb";
    static readonly string Username = Environment.GetEnvironmentVariable("DB_USER") ?? "postgres";
    static readonly string Password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "password";

    public static readonly string connectionString =
    $"""
    Host={Host};Port={Port};Database={Database};Username={Username};Password={Password};
    """;

    public static readonly string dummyGUID = "00000000-0000-0000-0000-000000000000";
}