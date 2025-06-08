using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

/// <summary>
/// Модель страницы аутентификации пользователей
/// </summary>
public class LoginModel : PageModel
{
    /// <summary>
    /// Имя пользователя для входа (привязка модели)
    /// </summary>
    [BindProperty]
    public string Username { get; set; }

    /// <summary>
    /// Пароль пользователя для входа (привязка модели)
    /// </summary>
    [BindProperty]
    public string Password { get; set; }

    /// <summary>
    /// Сообщение об ошибке аутентификации
    /// </summary>
    public string ErrorMessage { get; set; }

    /// <summary>
    /// Сообщение об успешной аутентификации
    /// </summary>
    public string SuccessMessage { get; set; }

    /// <summary>
    /// Обработчик POST-запроса для аутентификации пользователя
    /// </summary>
    /// <returns>
    /// Перенаправление на страницу администрирования при успешной аутентификации,
    /// или возврат на страницу входа с сообщением об ошибке
    /// </returns>
    /// <remarks>
    /// В текущей реализации используется тестовый логин/пароль: admin/admin
    /// </remarks>
    public IActionResult OnPost()
    {
        if (Username == "admin" && Password == "admin") // Замените на свою логику
        {
            HttpContext.Session.SetString("IsAdmin", "true");
            SuccessMessage = "Вы успешно вошли!";
            return RedirectToPage("/Events_admin");
        }
        else
        {
            ErrorMessage = "Неверный логин или пароль.";
            return Page();
        }
    }

    /// <summary>
    /// Обработчик POST-запроса для выхода из системы
    /// </summary>
    /// <returns>Перенаправление на страницу входа</returns>
    public IActionResult OnPostLogout()
    {
        HttpContext.Session.Remove("IsAdmin");
        return RedirectToPage("/Login");
    }
}