using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages
{
    /// <summary>
    /// Модель страницы для отображения прочих мероприятий (не относящихся к основным категориям)
    /// </summary>
    public class Other_eventsModel : PageModel
    {
        private readonly ILogger<Other_eventsModel> _logger;
        private readonly AppDbContext _context;

        /// <summary>
        /// Конструктор класса Other_eventsModel
        /// </summary>
        /// <param name="logger">Логгер для записи событий</param>
        /// <param name="context">Контекст базы данных</param>
        public Other_eventsModel(ILogger<Other_eventsModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Список мероприятий, не относящихся к основным категориям
        /// </summary>
        public List<Events> OtherEvents { get; set; }

        /// <summary>
        /// Обработчик GET-запроса для страницы прочих мероприятий
        /// </summary>
        /// <remarks>
        /// Загружает все мероприятия, исключая события из категорий: "Цирк", "Театр" и "Концерты"
        /// </remarks>
        public async Task OnGetAsync()
        {
            // Получаем Id категорий "цирк", "театр" и "концерт"
            var excludedCategories = await _context.Category
                .Where(c => c.NameCategory == "Цирк" || c.NameCategory == "Театр" || c.NameCategory == "Концерты")
                .Select(c => c.Id)
                .ToListAsync();

            // Получаем все события, исключая события из найденных категорий
            OtherEvents = await _context.Events
                .Where(e => !excludedCategories.Contains(e.Category))
                .ToListAsync();
        }
    }
}