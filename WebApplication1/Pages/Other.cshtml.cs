using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Pages
{
    /// <summary>
    /// ������ ��� ���������� ��������������� ���������� ������� (������������, ���������, ����� ����������)
    /// </summary>
    public class OtherModel
    {
        private readonly ILogger<OtherModel> _logger;
        private readonly AppDbContext _context;
        private readonly HttpContext _httpContext;

        /// <summary>
        /// ����������� ������ OtherModel
        /// </summary>
        /// <param name="logger">������ ��� ������ �������</param>
        /// <param name="context">�������� ���� ������</param>
        /// <param name="httpContextAccessor">������ � HTTP-���������</param>
        public OtherModel(ILogger<OtherModel> logger, AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _context = context;
            _httpContext = httpContextAccessor.HttpContext;
        }

        /// <summary>
        /// ������ ������������� �����������
        /// </summary>
        public List<Organizers> OrganizersList { get; set; }

        /// <summary>
        /// ������ ��������� �����������
        /// </summary>
        public List<Category> CategoryList { get; set; }

        /// <summary>
        /// ������ ���� ���������� �����������
        /// </summary>
        public List<LocationEvent> LocationList { get; set; }

        /// <summary>
        /// �������� ������ ������������ (��� ����������)
        /// </summary>
        public string? NewOrganizerName { get; set; }

        /// <summary>
        /// ID ������������ ��� ��������������
        /// </summary>
        public int EditOrganizerId { get; set; }

        /// <summary>
        /// ����� ��� ������������ (��� ��������������)
        /// </summary>
        public string EditOrganizerName { get; set; }

        /// <summary>
        /// ID ������������ ��� ��������
        /// </summary>
        public int DeleteId { get; set; }

        /// <summary>
        /// �������� ����� ���������
        /// </summary>
        public string? NewCategoryName { get; set; }

        /// <summary>
        /// ���������� ����������� ��� ����� ���������
        /// </summary>
        public string? NewCategoryAgeLimit { get; set; }

        /// <summary>
        /// ID ��������� ��� ��������������
        /// </summary>
        public int EditCategoryId { get; set; }

        /// <summary>
        /// ����� �������� ��������� (��� ��������������)
        /// </summary>
        public string EditCategoryName { get; set; }

        /// <summary>
        /// ����� ���������� ����������� ��������� (��� ��������������)
        /// </summary>
        public string EditCategoryAgeLimit { get; set; }

        /// <summary>
        /// ID ��������� ��� ��������
        /// </summary>
        public int DeleteCategoryId { get; set; }

        /// <summary>
        /// �������� ������ ����� ����������
        /// </summary>
        public string? NewLocationName { get; set; }

        /// <summary>
        /// ����� ������ ����� ����������
        /// </summary>
        public string? NewLocationAddress { get; set; }

        /// <summary>
        /// ID ����� ���������� ��� ��������������
        /// </summary>
        public int EditLocationId { get; set; }

        /// <summary>
        /// ����� �������� ����� ���������� (��� ��������������)
        /// </summary>
        public string EditLocationName { get; set; }

        /// <summary>
        /// ����� ����� ����� ���������� (��� ��������������)
        /// </summary>
        public string EditLocationAddress { get; set; }

        /// <summary>
        /// ID ����� ���������� ��� ��������
        /// </summary>
        public int DeleteLocationId { get; set; }

        /// <summary>
        /// ��������� ��� ������������ (�����)
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// ���� ����������� ���������
        /// </summary>
        public bool ShowMessage { get; set; } = false;

        /// <summary>
        /// ���� ����������� �������
        /// </summary>
        public bool ShowTable { get; set; } = false;

        /// <summary>
        /// ���������, ��������� � �����������
        /// </summary>
        public string? MessageCategory { get; set; }

        /// <summary>
        /// ���� ����������� ��������� � ����������
        /// </summary>
        public bool ShowMessageCategory { get; set; } = false;

        /// <summary>
        /// ���� ����������� ������� ���������
        /// </summary>
        public bool ShowTableCategory { get; set; } = false;

        /// <summary>
        /// ���������, ��������� � ������� ����������
        /// </summary>
        public string? MessageLocation { get; set; }

        /// <summary>
        /// ���� ����������� ��������� � ������ ����������
        /// </summary>
        public bool ShowMessageLocation { get; set; } = false;

        /// <summary>
        /// ���� ����������� ������� ���� ����������
        /// </summary>
        public bool ShowTableLocation { get; set; } = false;

        /// <summary>
        /// ��������� ������ ������������� �� ���� ������
        /// </summary>
        public async Task LoadOrganizersAsync()
        {
            OrganizersList = await _context.Organizers.ToListAsync();
        }
    }
}