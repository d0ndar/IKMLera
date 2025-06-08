using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Pages
{
    public class OtherModel
    {
        private readonly ILogger<OtherModel> _logger;
        private readonly AppDbContext _context;
        private readonly HttpContext _httpContext;


        public OtherModel(ILogger<OtherModel> logger, AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _context = context;
            _httpContext = httpContextAccessor.HttpContext;
        }
        public List<Organizers> OrganizersList { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<LocationEvent> LocationList { get; set; }
        public string? NewOrganizerName { get; set; } // Для добавления
        public int EditOrganizerId { get; set; } // Для редактирования
        public string EditOrganizerName { get; set; } // Для редактирования
        public int DeleteId { get; set; } // Для удаления
        public string? NewCategoryName { get; set; }
        public string? NewCategoryAgeLimit { get; set; }
        public int EditCategoryId { get; set; }
        public string EditCategoryName { get; set; }
        public string EditCategoryAgeLimit { get; set; }
        public int DeleteCategoryId { get; set; }

        public string? NewLocationName { get; set; }
        public string? NewLocationAddress { get; set; }
        public int EditLocationId { get; set; }
        public string EditLocationName { get; set; }
        public string EditLocationAddress { get; set; }
        public int DeleteLocationId { get; set; }
        public string? Message { get; set; }
        public bool ShowMessage { get; set; } = false;
        public bool ShowTable { get; set; } = false;
        public string? MessageCategory { get; set; }
        public bool ShowMessageCategory { get; set; } = false;
        public bool ShowTableCategory { get; set; } = false;
        public string? MessageLocation { get; set; }
        public bool ShowMessageLocation { get; set; } = false;
        public bool ShowTableLocation { get; set; } = false;

        public async Task LoadOrganizersAsync()
        {
            OrganizersList = await _context.Organizers.ToListAsync();
        }

    }
}





