using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Pages
{
    /// <summary>
    /// Модель для администрирования мероприятий
    /// </summary>
    public class EventsAdminModel
    {
        private readonly ILogger<EventsAdminModel> _logger;
        private readonly AppDbContext _context;
        private readonly HttpContext _httpContext;

        /// <summary>
        /// Конструктор класса EventsAdminModel
        /// </summary>
        /// <param name="logger">Логгер для записи событий</param>
        /// <param name="context">Контекст базы данных</param>
        /// <param name="httpContextAccessor">Доступ к контексту HTTP-запроса</param>
        public EventsAdminModel(
            ILogger<EventsAdminModel> logger,
            AppDbContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _context = context;
            _httpContext = httpContextAccessor.HttpContext;
        }

        /// <summary>
        /// Список мероприятий
        /// </summary>
        public List<Events> EventsList { get; set; }

        /// <summary>
        /// Сообщение для отображения пользователю
        /// </summary>
        public string? MessageEvents { get; set; }

        /// <summary>
        /// Флаг, указывающий нужно ли отображать сообщение
        /// </summary>
        public bool ShowMessageEvents { get; set; } = false;

        /// <summary>
        /// Флаг, указывающий нужно ли отображать таблицу мероприятий
        /// </summary>
        public bool ShowTableEvents { get; set; } = false;

        /// <summary>
        /// Загружает список мероприятий из базы данных
        /// </summary>
        /// <returns>Асинхронная задача</returns>
        public async Task LoadEventsAsync()
        {
            EventsList = await _context.Events.ToListAsync();
        }
    }
}