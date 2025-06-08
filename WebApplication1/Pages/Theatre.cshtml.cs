using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages
{
    public class TheatreModel : PageModel
    {
        private readonly ILogger<TheatreModel> _logger;
        private readonly AppDbContext _context;

        public TheatreModel(ILogger<TheatreModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Events> TheatreEvents { get; set; }

        public async Task OnGetAsync()
        {
            // Получаем идентификатор категории "театр"
            var theatreCategory = await _context.Category
                .FirstOrDefaultAsync(c => c.NameCategory == "Театр");

            if (theatreCategory == null)
            {
                TheatreEvents = new List<Events>(); // Если нет категории театр, то возвращаем пустой список
                return;
            }

            // Получаем все события, которые относятся к категории "театр"
            TheatreEvents = await _context.Events
                .Where(e => e.Category == theatreCategory.Id)
                .ToListAsync();
        }
    }
}

