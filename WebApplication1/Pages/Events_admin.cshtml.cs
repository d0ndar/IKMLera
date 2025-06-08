using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Pages
{
    public class EventsAdminModel
    {
        private readonly ILogger<EventsAdminModel> _logger;
        private readonly AppDbContext _context;
        private readonly HttpContext _httpContext;

        public EventsAdminModel(ILogger<EventsAdminModel> logger, AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _context = context;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public List<Events> EventsList { get; set; }

        public string? MessageEvents { get; set; }
        public bool ShowMessageEvents { get; set; } = false;
        public bool ShowTableEvents { get; set; } = false;

        public async Task LoadEventsAsync()
        {
            EventsList = await _context.Events.ToListAsync();
        }
    }
}


