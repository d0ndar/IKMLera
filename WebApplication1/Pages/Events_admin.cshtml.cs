using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Pages
{
    /// <summary>
    /// ������ ��� ����������������� �����������
    /// </summary>
    public class EventsAdminModel
    {
        private readonly ILogger<EventsAdminModel> _logger;
        private readonly AppDbContext _context;
        private readonly HttpContext _httpContext;

        /// <summary>
        /// ����������� ������ EventsAdminModel
        /// </summary>
        /// <param name="logger">������ ��� ������ �������</param>
        /// <param name="context">�������� ���� ������</param>
        /// <param name="httpContextAccessor">������ � ��������� HTTP-�������</param>
        public EventsAdminModel(
            ILogger<EventsAdminModel> logger,
            AppDbContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _context = context;
            _httpContext = httpContextAccessor.HttpContext;
        }

        /// <summary>
        /// ������ �����������
        /// </summary>
        public List<Events> EventsList { get; set; }

        /// <summary>
        /// ��������� ��� ����������� ������������
        /// </summary>
        public string? MessageEvents { get; set; }

        /// <summary>
        /// ����, ����������� ����� �� ���������� ���������
        /// </summary>
        public bool ShowMessageEvents { get; set; } = false;

        /// <summary>
        /// ����, ����������� ����� �� ���������� ������� �����������
        /// </summary>
        public bool ShowTableEvents { get; set; } = false;

        /// <summary>
        /// ��������� ������ ����������� �� ���� ������
        /// </summary>
        /// <returns>����������� ������</returns>
        public async Task LoadEventsAsync()
        {
            EventsList = await _context.Events.ToListAsync();
        }
    }
}