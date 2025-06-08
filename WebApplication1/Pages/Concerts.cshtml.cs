using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages
{
    public class ConcertsModel : PageModel
    {
        private readonly ILogger<ConcertsModel> _logger;
        private readonly AppDbContext _context;

        public ConcertsModel(ILogger<ConcertsModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Events> ConcertEvents { get; set; }

        public async Task OnGetAsync()
        {
            // Получаем идентификатор категории "концерт"
            var concertCategory = await _context.Category
                .FirstOrDefaultAsync(c => c.NameCategory == "Концерты");

            if (concertCategory == null)
            {
                ConcertEvents = new List<Events>(); // Если нет категории "концерт", то возвращаем пустой список
                return;
            }

            // Получаем все события, которые относятся к категории "концерт"
            ConcertEvents = await _context.Events
                .Where(e => e.Category == concertCategory.Id)
                .ToListAsync();
        }
    }
}


