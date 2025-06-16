using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BisiyonAdminPanel.Controllers
{
    public class ProvinceController : BaseController
    {
        public readonly BisiyonSaasMainDbContext _context;

        public ProvinceController(BisiyonSaasMainDbContext context)
        {
            _context = context;
        }

        public async Task<JsonResult> GetProvinces()
        {
            var provinces = await _context.Province.ToListAsync();
            return Json(provinces);
        }
    }
}