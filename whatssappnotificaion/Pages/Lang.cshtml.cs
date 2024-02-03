using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;

public class LangModel : PageModel
{
    private readonly ILogger<LangModel> _logger;

    public LangModel(ILogger<LangModel> logger)
    {
        _logger = logger;
    }

    public IActionResult OnGet()
    {
        string? culture = Request.Query["culture"];

        // Validate the culture parameter (optional)
        if (!IsValidCulture(culture))
        {
            _logger.LogWarning($"Invalid culture: {culture}");
            return BadRequest("Invalid culture");
        }

        _logger.LogInformation($"New selected language: {culture}");

        if (culture != null)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
        }

        string returnUrl = Request.Headers["Referer"].ToString() ?? "/";
        return LocalRedirect(returnUrl);
    }

    private bool IsValidCulture(string? culture)
    {
        // You can implement custom logic to validate the culture if needed
        // For simplicity, let's assume any non-null value is valid in this example
        return culture != null;
    }
}
