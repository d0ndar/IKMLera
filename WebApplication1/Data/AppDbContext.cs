using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Data
{
    /// <summary>
    /// Представляет сеанс взаимодействия с базой данных и обеспечивает доступ к сущностям.
    /// Наследуется от <see cref="DbContext"/> для работы с Entity Framework Core.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Конфигурация приложения, содержащая строки подключения и другие настройки.
        /// </summary>
        protected readonly IConfiguration _Configuration;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="AppDbContext"/> с указанной конфигурацией.
        /// </summary>
        /// <param name="configuration">Интерфейс конфигурации, предоставляющий доступ к настройкам приложения.</param>
        public AppDbContext(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        /// <summary>
        /// Настраивает параметры подключения к базе данных.
        /// </summary>
        /// <param name="options">Построитель опций контекста базы данных.</param>
        /// <remarks>
        /// Использует PostgreSQL в качестве провайдера БД с строкой подключения "WebApiDatabase".
        /// </remarks>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_Configuration.GetConnectionString("WebApiDatabase"));
        }

        /// <summary>
        /// Набор данных для сущностей "Организаторы".
        /// </summary>
        public DbSet<Organizers> Organizers { get; set; }

        /// <summary>
        /// Набор данных для сущностей "Места проведения событий".
        /// </summary>
        public DbSet<LocationEvent> LocationEvents { get; set; }

        /// <summary>
        /// Набор данных для сущностей "Категории событий".
        /// </summary>
        public DbSet<Category> Category { get; set; }

        /// <summary>
        /// Набор данных для сущностей "События".
        /// </summary>
        public DbSet<Events> Events { get; set; }
    }
}