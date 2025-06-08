using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    [Table("organizers")]
    public class Organizers
    {
        [Column("id_organizers")]
        public int Id { get; set; }
        [Column("name_organizers")]
        public string NameOrganizers { get; set; }
    }
}
