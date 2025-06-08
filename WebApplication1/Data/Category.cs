using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    /// <summary>
    /// Представляет категорию событий в системе.
    /// Соответствует таблице "category" в базе данных.
    /// </summary>
    [Table("category")]
    public class Category
    {
        /// <summary>
        /// Уникальный идентификатор категории.
        /// Соответствует столбцу "id_category" в таблице.
        /// </summary>
        [Column("id_category")]
        public int Id { get; set; }

        /// <summary>
        /// Название категории.
        /// Соответствует столбцу "name_category" в таблице.
        /// </summary>
        [Column("name_category")]
        public string NameCategory { get; set; }
    }
}