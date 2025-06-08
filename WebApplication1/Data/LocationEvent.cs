using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    /// <summary>
    /// Представляет место проведения событий в системе.
    /// Соответствует таблице "location_events" в базе данных.
    /// </summary>
    [Table("location_events")]
    public class LocationEvent
    {
        /// <summary>
        /// Уникальный идентификатор места проведения.
        /// Соответствует столбцу "id_location_events" в таблице.
        /// </summary>
        [Key]
        [Column("id_location_events")]
        public int Id { get; set; }

        /// <summary>
        /// Название места проведения.
        /// Обязательное поле, максимальная длина - 100 символов.
        /// Соответствует столбцу "name_location" в таблице.
        /// </summary>
        [Required(ErrorMessage = "Название места обязательно")]
        [StringLength(100, ErrorMessage = "Название не должно превышать 100 символов")]
        [Column("name_location")]
        public string NameLocation { get; set; }

        /// <summary>
        /// Адрес места проведения.
        /// Обязательное поле, максимальная длина - 200 символов.
        /// Соответствует столбцу "address" в таблице.
        /// </summary>
        [Required(ErrorMessage = "Адрес места обязателен")]
        [StringLength(200, ErrorMessage = "Адрес не должен превышать 200 символов")]
        [Column("address")]
        public string Address { get; set; }
    }
}