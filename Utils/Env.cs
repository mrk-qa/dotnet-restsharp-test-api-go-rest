using DotNetEnv;

public static class EnvConfig
{
    static EnvConfig()
    {
        // Carrega o .env automaticamente ao iniciar
        DotNetEnv.Env.TraversePath().Load();
    }

    public static string GorestToken => Environment.GetEnvironmentVariable("GOREST_TOKEN")!;
}
