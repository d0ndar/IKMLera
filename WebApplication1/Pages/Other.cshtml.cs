using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Pages
{
    /// <summary>
    /// Модель для управления дополнительными сущностями системы (организаторы, категории, места проведения)
    /// </summary>
    public class OtherModel
    {
        private readonly ILogger<OtherModel> _logger;
        private readonly AppDbContext _context;
        private readonly HttpContext _httpContext;

        /// <summary>
        /// Конструктор класса OtherModel
        /// </summary>
        /// <param name="logger">Логгер для записи событий</param>
        /// <param name="context">Контекст базы данных</param>
        /// <param name="httpContextAccessor">Доступ к HTTP-контексту</param>
        public OtherModel(ILogger<OtherModel> logger, AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _context = context;
            _httpContext = httpContextAccessor.HttpContext;
        }

        /// <summary>
        /// Список организаторов мероприятий
        /// </summary>
        public List<Organizers> OrganizersList { get; set; }

        /// <summary>
        /// Список категорий мероприятий
        /// </summary>
        public List<Category> CategoryList { get; set; }

        /// <summary>
        /// Список мест проведения мероприятий
        /// </summary>
        public List<LocationEvent> LocationList { get; set; }

        /// <summary>
        /// Название нового организатора (для добавления)
        /// </summary>
        public string? NewOrganizerName { get; set; }

        /// <summary>
        /// ID организатора для редактирования
        /// </summary>
        public int EditOrganizerId { get; set; }

        /// <summary>
        /// Новое имя организатора (для редактирования)
        /// </summary>
        public string EditOrganizerName { get; set; }

        /// <summary>
        /// ID организатора для удаления
        /// </summary>
        public int DeleteId { get; set; }

        /// <summary>
        /// Название новой категории
        /// </summary>
        public string? NewCategoryName { get; set; }

        /// <summary>
        /// Возрастное ограничение для новой категории
        /// </summary>
        public string? NewCategoryAgeLimit { get; set; }

        /// <summary>
        /// ID категории для редактирования
        /// </summary>
        public int EditCategoryId { get; set; }

        /// <summary>
        /// Новое название категории (для редактирования)
        /// </summary>
        public string EditCategoryName { get; set; }

        /// <summary>
        /// Новое возрастное ограничение категории (для редактирования)
        /// </summary>
        public string EditCategoryAgeLimit { get; set; }

        /// <summary>
        /// ID категории для удаления
        /// </summary>
        public int DeleteCategoryId { get; set; }

        /// <summary>
        /// Название нового места проведения
        /// </summary>
        public string? NewLocationName { get; set; }

        /// <summary>
        /// Адрес нового места проведения
        /// </summary>
        public string? NewLocationAddress { get; set; }

        /// <summary>
        /// ID места проведения для редактирования
        /// </summary>
        public int EditLocationId { get; set; }

        /// <summary>
        /// Новое название места проведения (для редактирования)
        /// </summary>
        public string EditLocationName { get; set; }

        /// <summary>
        /// Новый адрес места проведения (для редактирования)
        /// </summary>
        public string EditLocationAddress { get; set; }

        /// <summary>
        /// ID места проведения для удаления
        /// </summary>
        public int DeleteLocationId { get; set; }

        /// <summary>
        /// Сообщение для пользователя (общее)
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Флаг отображения сообщения
        /// </summary>
        public bool ShowMessage { get; set; } = false;

        /// <summary>
        /// Флаг отображения таблицы
        /// </summary>
        public bool ShowTable { get; set; } = false;

        /// <summary>
        /// Сообщение, связанное с категориями
        /// </summary>
        public string? MessageCategory { get; set; }

        /// <summary>
        /// Флаг отображения сообщения о категориях
        /// </summary>
        public bool ShowMessageCategory { get; set; } = false;

        /// <summary>
        /// Флаг отображения таблицы категорий
        /// </summary>
        public bool ShowTableCategory { get; set; } = false;

        /// <summary>
        /// Сообщение, связанное с местами проведения
        /// </summary>
        public string? MessageLocation { get; set; }

        /// <summary>
        /// Флаг отображения сообщения о местах проведения
        /// </summary>
        public bool ShowMessageLocation { get; set; } = false;

        /// <summary>
        /// Флаг отображения таблицы мест проведения
        /// </summary>
        public bool ShowTableLocation { get; set; } = false;

        /// <summary>
        /// Загружает список организаторов из базы данных
        /// </summary>
        public async Task LoadOrganizersAsync()
        {
            OrganizersList = await _context.Organizers.ToListAsync();
        }
    }
}