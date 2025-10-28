using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.DTOs
{
    public class SupplierDTO
    {
        [Key]
        [StringLength(50, ErrorMessage = "SupplierCompanyID cannot exceed 50 characters.")]
        public string SupplierCompanyID { get; set; } = string.Empty;

        [StringLength(250, ErrorMessage = "SupplierCompanyName cannot exceed 250 characters.")]
        public string SupplierCompanyName { get; set; } = string.Empty;

        public string? Address { get; set; }

        [StringLength(250, ErrorMessage = "Phone cannot exceed 250 characters.")]
        public string? Phone { get; set; }

        [StringLength(50, ErrorMessage = "Mobile cannot exceed 50 characters.")]
        public string? Mobile { get; set; }

        [StringLength(50, ErrorMessage = "Fax cannot exceed 50 characters.")]
        public string? Fax { get; set; }

        public DateTime? CreateDate { get; set; } = DateTime.Now;

        [StringLength(250, ErrorMessage = "CreateBy cannot exceed 250 characters.")]
        public string? CreateBy { get; set; }

        [StringLength(250, ErrorMessage = "UpdateBy cannot exceed 250 characters.")]
        public string? UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public byte[]? Logo { get; set; }

        public bool? IsCashBack { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "OpeningAmt must be a positive number.")]
        public decimal? OpeningAmt { get; set; }
    }
}
