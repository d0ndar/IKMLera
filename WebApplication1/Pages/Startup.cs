using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

/// <summary>
/// Класс настройки приложения, содержащий конфигурацию сервисов и middleware
/// </summary>
public class Startup
{
    /// <summary>
    /// Метод для добавления сервисов в контейнер DI
    /// </summary>
    /// <param name="services">Коллекция сервисов приложения</param>
    /// <remarks>
    /// Регистрирует:
    /// - Razor Pages
    /// - Сервис сессий
    /// </remarks>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddSession(); // Добавьте это для поддержки сессий
    }

    /// <summary>
    /// Метод для настройки конвейера HTTP-запросов
    /// </summary>
    /// <param name="app">Построитель приложения</param>
    /// <param name="env">Среда выполнения приложения</param>
    /// <remarks>
    /// Настраивает:
    /// - Обработку исключений в зависимости от среды
    /// - HTTPS редиректы
    /// - Статические файлы
    /// - Маршрутизацию
    /// - Сессии
    /// - Авторизацию
    /// - Конечные точки Razor Pages
    /// </remarks>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseSession(); // Включите поддержку сессий

        app.UseAuthorization();

        app.UseStaticFiles();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
        });
    }
}