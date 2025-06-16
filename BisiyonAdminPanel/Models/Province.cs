using System.ComponentModel.DataAnnotations;

namespace BisiyonAdminPanel
{
    public class Province
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}