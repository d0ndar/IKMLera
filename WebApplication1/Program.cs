using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

/// <summary>
/// Главный класс приложения, содержащий точку входа и конфигурацию сервисов.
/// </summary>
public class Program
{
    /// <summary>
    /// Точка входа в приложение.
    /// </summary>
    /// <param name="args">Аргументы командной строки.</param>
    /// <remarks>
    /// Настраивает и запускает веб-приложение с использованием:
    /// - Razor Pages
    /// - Сессий с 20-минутным таймаутом
    /// - PostgreSQL базы данных
    /// - Кэша в памяти
    /// - Статических файлов
    /// </remarks>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Конфигурация сервисов
        builder.Services.AddRazorPages();
        builder.Services.AddSession();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddDistributedMemoryCache();

        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(20);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        app.UseSession();

        app.UseRouting();
        app.UseAuthorization();

        app.MapRazorPages();

        app.UseStaticFiles();

        app.Run();
    }
}