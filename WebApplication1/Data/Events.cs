using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    /// <summary>
    /// Представляет событие в системе.
    /// Соответствует таблице "events" в базе данных.
    /// </summary>
    [Table("events")]
    public class Events
    {
        /// <summary>
        /// Уникальный идентификатор события.
        /// Соответствует столбцу "id_event" в таблице.
        /// </summary>
        [Column("id_event")]
        public int Id { get; set; }

        /// <summary>
        /// Название события.
        /// Соответствует столбцу "title" в таблице.
        /// </summary>
        [Column("title")]
        public string Title { get; set; }

        /// <summary>
        /// Подробное описание события.
        /// Соответствует столбцу "description" в таблице.
        /// </summary>
        [Column("description")]
        public string Description { get; set; }

        /// <summary>
        /// Дата и время проведения события.
        /// Соответствует столбцу "date_event" в таблице.
        /// </summary>
        [Column("date_event")]
        public DateTime DateEvent { get; set; }

        /// <summary>
        /// Идентификатор места проведения события.
        /// Соответствует столбцу "location" в таблице.
        /// Связь с таблицей LocationEvents.
        /// </summary>
        [Column("location")]
        public int Location { get; set; }

        /// <summary>
        /// Максимальная вместимость (количество участников).
        /// Соответствует столбцу "capacity" в таблице.
        /// </summary>
        [Column("capacity")]
        public int Capacity { get; set; }

        /// <summary>
        /// Цена билета на событие.
        /// Соответствует столбцу "ticket_price" в таблице.
        /// </summary>
        [Column("ticket_price")]
        public int TicketPrice { get; set; }

        /// <summary>
        /// Идентификатор категории события.
        /// Соответствует столбцу "category" в таблице.
        /// Связь с таблицей Category.
        /// </summary>
        [Column("category")]
        public int Category { get; set; }

        /// <summary>
        /// Идентификатор организатора/спонсора события.
        /// Соответствует столбцу "sponsor" в таблице.
        /// Связь с таблицей Organizers.
        /// </summary>
        [Column("sponsor")]
        public int Sponsor { get; set; }
    }
}