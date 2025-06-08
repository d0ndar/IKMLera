using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    [Table("location_events")]
    public class LocationEvent
    {
        [Column("id_location_events")]
        public int Id { get; set; }
        [Column("name_location")]
        public string NameLocation { get; set; }
        [Column("address")]
        public string Address { get; set; }
    }
}
