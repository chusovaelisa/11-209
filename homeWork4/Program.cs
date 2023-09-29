using System.Net;
using lisachusova;
using lisachusova;
using lisachusova.Configuration;
using Newtonsoft.Json;

class Program
{
    private static async Task Main()
    {
        var server = Server.Instance;
        await server.RunAsync();
        Console.ReadKey();
    }
}

class Server
{
    private static readonly CancellationTokenSource _source = new();
    private static readonly Lazy<Server> _lazy = new Lazy<Server>(() => new Server());
    private static readonly HttpListener _listener = new HttpListener();
    
    private Server()
    {
        
    }

    public static Server Instance => _lazy.Value;

    public async Task RunAsync()
    {
        var token = _source.Token;
        Task.Run(() => StartServer(token));
        Task.Run(StopServer);
    }

    private async Task StartServer(CancellationToken token)
    {
        var isSuccess = await ApplyServerConfiguration();
        Console.WriteLine(isSuccess);
        var appConfig = await GetConfigurationAsync();
        if (isSuccess)
        {
            if (token.IsCancellationRequested)
                return;

            while (true)
            {
                if (token.IsCancellationRequested)
                    return;
            
                var context = await _listener.GetContextAsync();
                using var response = context.Response;
                var request = context.Request;

                var requestPath = request.Url!.AbsolutePath;
                var pathOfFile = Path.Combine(appConfig.StaticFile, requestPath.Trim('/'));
                if (requestPath.EndsWith('/'))
                {
                    var pathOfIndex = Path.Combine(pathOfFile, "index.html");
                    var buffer = await File.ReadAllBytesAsync(pathOfIndex, token);
                    response.ContentLength64 = buffer.Length;
                    await response.OutputStream.WriteAsync(buffer, 0, buffer.Length, token);
                }
                else if (requestPath == "/login")
                {
                    await using var body = request.InputStream;
                    using var streamReader = new StreamReader(body);
                    var dataOfUser = await streamReader.ReadToEndAsync(token);
                    var buffer = dataOfUser.Split('&');
                    var isSend = await MailSender.SendEmailAsync(buffer[0], buffer[1], "Hello from admin liza");
                    if(isSend)
                        Console.WriteLine("Email has been sent.");
                }
                else
                {
                    if (File.Exists(pathOfFile))
                    {
                        response.ContentType = GetContentType(pathOfFile);
                        var buffer = await File.ReadAllBytesAsync(pathOfFile, token);
                        response.ContentLength64 = buffer.Length;
                        await response.OutputStream.WriteAsync(buffer, 0, buffer.Length, token);
                    }
                    else
                    {
                        Console.WriteLine($"Path {pathOfFile} not found.");
                    }
                }
            } 
            //_listener.Close();
        }
        else
        {
            Console.WriteLine("Ошибки с конфигурацией сервера, обратитесь в метод ApplyServerConfiguration.");
        }
    }

    private string GetContentType(string requestPath)
    {
        var type = Path.GetExtension(requestPath);
        return type switch
        {
            ".css" => "text/css",
            ".img" => "image/jpeg",
            ".svg" => "image/svg+xml",
            _ => "undefined"
        };
    }

    private async Task StopServer()
    {
        while (true)
        {
            if (Console.ReadLine() != "stop") continue;
            _source.Cancel();
            await Task.Delay(4000);
            break;
        }
    }


    private async Task<bool> ApplyServerConfiguration()
    {
        var config = await GetConfigurationAsync();
        EnsureDirectory(config);
        _listener.Prefixes.Add($"{config.Address}:{config.Port}/");
        _listener.Start();
        Console.WriteLine($"Server has been started on address: {config.Address}:{config.Port}/");
        return true;
    }


    private async Task<AppSettingsConfig?> GetConfigurationAsync()
    {
        try
        {
            var json = await File.OpenText("appsettings.json").ReadToEndAsync();
            return JsonConvert.DeserializeObject<AppSettingsConfig>(json);
        }
        catch (Exception e)
        {
            Console.WriteLine("Файл appsettings.json не был найден.");
            throw;
        }
    }

    private void EnsureDirectory(AppSettingsConfig config)
    {
        if (Directory.Exists(config.StaticFile)) return;
        if (config.StaticFile != null)
            Directory.CreateDirectory(config.StaticFile);
    }
}