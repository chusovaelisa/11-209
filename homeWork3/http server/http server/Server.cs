using System.Net;
using Newtonsoft.Json;

namespace http_server;

public class Server
{
    public async Task Slay()
    {
        HttpListener server = new HttpListener();

        try
        {
            var json = await File.OpenText("appsettings.json").ReadToEndAsync();
            var appConfig = JsonConvert.DeserializeObject<Appsetting>(json);


            server.Prefixes.Add($"http://{appConfig.Address}:{appConfig.Port}/");


            Console.WriteLine("Запуск сервера");
            server.Start();

            Console.WriteLine("Сервер успешно запущен");

            while (true)
            {
                var context = await server.GetContextAsync();
                var url = context.Request.Url;
                var response = context.Response;

                // Определяем путь к запрашиваемому ресурсу
                string requestedPath = url.AbsolutePath;
                
                if (requestedPath.EndsWith(".html"))
                {
                    var filePath = Path.Combine(appConfig.staticPathFiles, requestedPath.Trim('/'));
                    if (File.Exists(filePath))
                    {
                        response.ContentType = "text/html";
                        var buffer = await File.ReadAllBytesAsync(filePath);
                        response.ContentLength64 = buffer.Length;
                        await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                    }
                }
                else if (requestedPath.EndsWith(".css"))
                {
                    var filePath = Path.Combine(appConfig.staticPathFiles, requestedPath.Trim('/'));
                    response.ContentType = "text/css";
                    var buffer = await File.ReadAllBytesAsync(filePath);
                    response.ContentLength64 = buffer.Length;
                    await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                }
                else if (requestedPath.EndsWith(".jpg"))
                {
                    var filePath = Path.Combine(appConfig.staticPathFiles, requestedPath.Trim('/'));
                    response.ContentType = "image/jpeg";
                    var buffer = await File.ReadAllBytesAsync(filePath);
                    response.ContentLength64 = buffer.Length;
                    await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                }
                else if (requestedPath.EndsWith(".png"))
                {
                    var filePath = Path.Combine(appConfig.staticPathFiles, requestedPath.Trim('/'));
                    response.ContentType = "image/png";
                    var buffer = await File.ReadAllBytesAsync(filePath);
                    response.ContentLength64 = buffer.Length;
                    await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                }
                else if (requestedPath.EndsWith(".svg"))
                {
                    var filePath = Path.Combine(appConfig.staticPathFiles, requestedPath.Trim('/'));
                    response.ContentType = "image/svg+xml";
                    var buffer = await File.ReadAllBytesAsync(filePath);
                    response.ContentLength64 = buffer.Length;
                    await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                }
                else
                {
                    var filePath = Path.Combine(appConfig.staticPathFiles, "index.html");
                    if (File.Exists(filePath))
                    {
                        response.ContentType = "text/html";
                        var buffer = await File.ReadAllBytesAsync(filePath);
                        response.ContentLength64 = buffer.Length;
                        await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                    }
                    else
                    {
                        Console.WriteLine("Not found");
                    }
                }
                response.Close();
                Console.WriteLine($"Запрос обработан для: {requestedPath}");
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Файл настроек appsettings.json не найден");
        }
        catch (Exception ex)
        {
            Console.WriteLine("В процессе работы возникла не предвиденная ошибка");
        }
        finally
        {
            server.Stop();
            Console.WriteLine("Сервер завершил свою работу");
        }
    }
}