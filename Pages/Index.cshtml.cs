using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AmadouDialloPortfolio.Services;

namespace AmadouDialloPortfolio.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly VisitorCountService _visitorCountService;

    public IndexModel(ILogger<IndexModel> logger, VisitorCountService visitorCountService)
    {
        _logger = logger;
        _visitorCountService = visitorCountService;
    }

    public void OnGet()
    {
        _visitorCountService.IncrementTotalVisits();
        _visitorCountService.IncrementPageVisit("Home");
    }
}
