using InventoryManagement.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.DTOs
{
    public class CategoryDTO
    {
        public string? CategoryID { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(250, ErrorMessage = "Category name cannot exceed 250 characters.")]
        public string CategoryName { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [Range(0, 100, ErrorMessage = "VAT must be between 0 and 100.")]
        public decimal? Vat { get; set; }

        [StringLength(250)]
        public string? CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(250)]
        public string? UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}

