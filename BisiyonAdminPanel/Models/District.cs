using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisiyonAdminPanel
{
    public class District
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ProvinceId { get; set; }

        [ForeignKey(nameof(ProvinceId))]
        public required virtual Province Province { get; set; }
    }
}