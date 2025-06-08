using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace WebApplication1.Pages
{
    /// <summary>
    /// Модель страницы для обработки и отображения ошибок приложения
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        /// <summary>
        /// Идентификатор запроса, для которого произошла ошибка
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Указывает, доступен ли идентификатор запроса для отображения
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        /// <summary>
        /// Конструктор класса ErrorModel
        /// </summary>
        /// <param name="logger">Логгер для записи информации об ошибках</param>
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Обработчик GET-запроса для страницы ошибки
        /// </summary>
        /// <remarks>
        /// Устанавливает RequestId из текущего Activity или TraceIdentifier
        /// </remarks>
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}