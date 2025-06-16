using System.ComponentModel.DataAnnotations.Schema;

namespace BisiyonAdminPanel
{
    public class Company
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public string? Address { get; set; }
        public string? TaxNumber { get; set; }
        public string? MersisNumber { get; set; }
        public string? OwnerFullName { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey(nameof(ProvinceId))]
        public required virtual Province Province { get; set; }

        [ForeignKey(nameof(DistrictId))]
        public required virtual District District { get; set; }
    }
}