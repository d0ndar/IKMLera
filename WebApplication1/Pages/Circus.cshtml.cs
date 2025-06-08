using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Модель страницы для отображения цирковых мероприятий
/// </summary>
public class CircusModel : PageModel
{
    private readonly ILogger<CircusModel> _logger;
    private readonly AppDbContext _context;

    /// <summary>
    /// Конструктор модели страницы
    /// </summary>
    /// <param name="logger">Логгер для записи событий</param>
    /// <param name="context">Контекст базы данных</param>
    public CircusModel(ILogger<CircusModel> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    /// <summary>
    /// Список цирковых мероприятий
    /// </summary>
    public List<Events> CircusEvents { get; set; }

    /// <summary>
    /// Обработчик GET-запроса для страницы
    /// </summary>
    /// <returns>Задача, представляющая асинхронную операцию</returns>
    public async Task OnGetAsync()
    {
        // Получаем идентификатор категории "цирк"
        var circusCategory = await _context.Category
            .FirstOrDefaultAsync(c => c.NameCategory == "Цирк");

        if (circusCategory == null)
        {
            CircusEvents = new List<Events>();
            return;
        }

        // Получаем все события, которые относятся к категории "цирк"
        CircusEvents = await _context.Events
            .Where(e => e.Category == circusCategory.Id)
            .ToListAsync();
    }
}