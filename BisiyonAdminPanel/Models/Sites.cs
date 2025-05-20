using System.ComponentModel.DataAnnotations;

namespace BisiyonAdminPanel
{
    public class Sites : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public Guid TenantId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string SiteCode { get; set; }

        [Required]
        [MaxLength(1000)]
        public string SiteName { get; set; }

        [MaxLength(500)]
        public string? DatabaseInfo { get; set; }
        public string? SiteAddress { get; set; }
        public DateTime CreatedDate { get; set; }

        [MaxLength(500)]
        public string? OwnerName { get; set; }

        [MaxLength(100)]
        public string? OwnerEmail { get; set; }

        [MaxLength(100)]
        public string? OwnerAlternateEmail { get; set; }

        [MaxLength(100)]
        public string? OwnerPhone { get; set; }

        [MaxLength(100)]
        public string? OwnerAlternatePhone { get; set; }
        public string? OwnerAddress { get; set; }
        public DateTime? ExpireDate { get; set; }
        public bool IsActive { get; set; }
    }
}