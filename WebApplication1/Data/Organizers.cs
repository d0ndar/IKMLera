using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    /// <summary>
    /// Представляет организатора мероприятий в системе.
    /// Соответствует таблице "organizers" в базе данных.
    /// </summary>
    [Table("organizers")]
    public class Organizers
    {
        /// <summary>
        /// Уникальный идентификатор организатора.
        /// Первичный ключ таблицы.
        /// Соответствует столбцу "id_organizers" в БД.
        /// </summary>
        [Key]
        [Column("id_organizers")]
        public int Id { get; set; }

        /// <summary>
        /// Название организации/организатора.
        /// Обязательное поле, максимальная длина - 150 символов.
        /// Соответствует столбцу "name_organizers" в БД.
        /// </summary>
        [Required(ErrorMessage = "Название организатора обязательно")]
        [StringLength(150, ErrorMessage = "Название не должно превышать 150 символов")]
        [Column("name_organizers")]
        public string NameOrganizers { get; set; }
    }
}