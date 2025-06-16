using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BisiyonAdminPanel.Controllers;

public class SiteController : BaseController
{
    private readonly ILogger<SiteController> _logger;
    private readonly BisiyonSaasMainDbContext _context;

    public SiteController(
        ILogger<SiteController> logger
      , BisiyonSaasMainDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    #region Actions

    public IActionResult Index()
    {
        return View();
    }

    #endregion

    #region Gets

    [HttpGet]
    public async Task<JsonResult> GetSites()
    {
        List<Sites> sites = await _context.Sites.ToListAsync();
        return Json(sites);
    }

    #endregion

    #region Posts

    [HttpPost]
    public async Task<JsonResult> SaveSite([FromBody] Sites site)
    {
        site.CreatedDate = DateTime.Now;
        site.IsActive = true;
        site.TenantId = Guid.NewGuid();
        await _context.Sites.AddAsync(site);
        var result = await _context.SaveChangesAsync();
        return Json(result);
    }

    #endregion
}
