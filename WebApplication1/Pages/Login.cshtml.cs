using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

public class LoginModel : PageModel
{
    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public string ErrorMessage { get; set; }
    public string SuccessMessage { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (Username == "admin" && Password == "admin") // Замените на свою логику
        {
            HttpContext.Session.SetString("IsAdmin", "true");
            SuccessMessage = "Вы успешно вошли!";
            return RedirectToPage("/Events_admin");
        }
        else
        {
            ErrorMessage = "Неверный логин или пароль.";
            return Page();
        }
    }

    public IActionResult OnPostLogout()
    {
        HttpContext.Session.Remove("IsAdmin");
        return RedirectToPage("/Login");
    }
}


