using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    [Table("category")] // Указываем имя таблицы в БД
    public class Category
    {
        [Column("id_category")] //Указываем имя столбца
        public int Id { get; set; }
        [Column("name_category")] //Указываем имя столбца
        public string NameCategory { get; set; }

    }
}
