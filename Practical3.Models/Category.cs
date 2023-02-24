using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Practical3.Models
{
    public class Category
    {
        [Key]
        [JsonIgnore]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}
