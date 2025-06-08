using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

public class CircusModel : PageModel
{
    private readonly ILogger<CircusModel> _logger;
    private readonly AppDbContext _context;

    public CircusModel(ILogger<CircusModel> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public List<Events> CircusEvents { get; set; }

    public async Task OnGetAsync()
    {
        // Получаем идентификатор категории "цирк"
        var circusCategory = await _context.Category
            .FirstOrDefaultAsync(c => c.NameCategory == "Цирк");

        if (circusCategory == null)
        {
            CircusEvents = new List<Events>();
            return;
        }

        // Получаем все события, которые относятся к категории "цирк"
        CircusEvents = await _context.Events
            .Where(e => e.Category == circusCategory.Id)
            .ToListAsync();
    }
}



