using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    /// <summary>
    /// Модель главной страницы приложения
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Конструктор класса IndexModel
        /// </summary>
        /// <param name="logger">Логгер для записи событий</param>
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Обработчик GET-запроса для главной страницы
        /// </summary>
    }
}