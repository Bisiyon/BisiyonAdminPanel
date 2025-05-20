using System.ComponentModel.DataAnnotations;

namespace BisiyonAdminPanel
{
    public class BaseEntity
    {
        [Timestamp]
        public byte[] ConcurrencyToken { get; set; }
    }
}