using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Добавляем сервисы для аутентификации
        builder.Services.AddRazorPages();
        builder.Services.AddSession(); // Добавляем поддержку сессий
                                       //регистрация контекста
        builder.Services.AddHttpContextAccessor();
        //регистрация IHttpContextAccessor
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(20);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        // Регистрация AppDbContext
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        app.UseSession(); // Используем сессии

        app.UseRouting();
        app.UseAuthorization();

        app.MapRazorPages();

        app.UseStaticFiles();

        app.Run();
    }
}

