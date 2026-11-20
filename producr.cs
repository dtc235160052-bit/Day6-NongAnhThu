
using System.ComponentModel.DataAnnotations;

namespace Day6_NongAnhThu.Models
{
    public class producr
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "Name must be between 3 and 100 characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(0, double.MaxValue,
            ErrorMessage = "Price must be greater than or equal to 0")]
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
