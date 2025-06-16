using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BisiyonAdminPanel.Controllers
{
    public class CompanyController : BaseController
    {
        public readonly BisiyonSaasMainDbContext _context;

        public CompanyController(BisiyonSaasMainDbContext context)
        {
            _context = context;
        }

        #region Actions

        public IActionResult Index()
        {
            return View();
        }

        #endregion Actions

        #region  Gets

        [HttpGet]
        public async Task<JsonResult> GetCompanies()
        {
            var companies = await _context.Company.Include(x => x.Province).Include(x => x.District).ToListAsync();
            return Json(companies);
        }

        #endregion Gets

        #region  Posts

        [HttpPost]
        public async Task<JsonResult> SaveCompany(Company company)
        {
            company.CreatedDate = DateTime.Now;
            company.IsActive = true;
            await _context.AddAsync(company);
            var result = await _context.SaveChangesAsync();
            return Json(result);
        }

        #endregion Posts
    }
}