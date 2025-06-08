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
    /// Модель страницы для отображения концертных мероприятий
    /// </summary>
    public class ConcertsModel : PageModel
    {
        private readonly ILogger<ConcertsModel> _logger;
        private readonly AppDbContext _context;

        /// <summary>
        /// Конструктор класса ConcertsModel
        /// </summary>
        /// <param name="logger">Логгер для записи событий</param>
        /// <param name="context">Контекст базы данных</param>
        public ConcertsModel(ILogger<ConcertsModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Список концертных мероприятий
        /// </summary>
        public List<Events> ConcertEvents { get; set; }

        /// <summary>
        /// Обработчик GET-запроса для страницы концертов
        /// </summary>
        /// <remarks>
        /// Загружает все события из категории "Концерты"
        /// </remarks>
        public async Task OnGetAsync()
        {
            // Получаем идентификатор категории "концерт"
            var concertCategory = await _context.Category
                .FirstOrDefaultAsync(c => c.NameCategory == "Концерты");

            if (concertCategory == null)
            {
                ConcertEvents = new List<Events>(); // Если нет категории "концерт", то возвращаем пустой список
                return;
            }

            // Получаем все события, которые относятся к категории "концерт"
            ConcertEvents = await _context.Events
                .Where(e => e.Category == concertCategory.Id)
                .ToListAsync();
        }
    }
}