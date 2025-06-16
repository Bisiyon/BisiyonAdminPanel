using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BisiyonAdminPanel.Controllers
{
    public class DistrictController : BaseController
    {
        public readonly BisiyonSaasMainDbContext _context;

        public DistrictController(BisiyonSaasMainDbContext context)
        {
            _context = context;
        }

        public async Task<JsonResult> GetDistricts(int id)
        {
            var districts = await _context.District.Where(x => x.ProvinceId == id).ToListAsync();
            return Json(districts);
        }
    }
}