using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    /// <summary>
    /// Модель страницы "Доступ запрещен".
    /// Отображается при попытке доступа к защищенным ресурсам без соответствующих прав.
    /// </summary>
    public class AccessDeniedModel : PageModel
    {
        private readonly ILogger<AccessDeniedModel> _logger;

        /// <summary>
        /// Конструктор с внедрением зависимостей.
        /// </summary>
        /// <param name="logger">Логгер для записи событий доступа.</param>
        public AccessDeniedModel(ILogger<AccessDeniedModel> logger)
        {
            _logger = logger;
        }
    }
}