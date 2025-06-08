using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Data
{
    [Table("events")] // Указываем имя таблицы в БД
    public class Events
    {
        [Column("id_event")] //Указываем имя столбца
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("date_event")]
        public DateTime DateEvent { get; set; }

        [Column("location")]
        public int Location { get; set; }

        [Column("capacity")]
        public int Capacity { get; set; }

        [Column("ticket_price")]
        public int TicketPrice { get; set; }

        [Column("category")]
        public int Category { get; set; }

        [Column("sponsor")]
        public int Sponsor { get; set; }
    }
}

