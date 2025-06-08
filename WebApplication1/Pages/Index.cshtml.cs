using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    /// <summary>
    /// ������ ������� �������� ����������
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// ����������� ������ IndexModel
        /// </summary>
        /// <param name="logger">������ ��� ������ �������</param>
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// ���������� GET-������� ��� ������� ��������
        /// </summary>
    }
}