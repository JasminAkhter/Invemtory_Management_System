using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.DTOs
{
    public class CustomerSetupDTO
    {
        [Key]
        public string CustomerID { get; set; } = string.Empty;

        [Required(ErrorMessage = "CustomerName is required.")]
        [StringLength(250, ErrorMessage = "CustomerName cannot exceed 250 characters.")]
        public string CustomerName { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "ContactName cannot exceed 50 characters.")]
        public string? ContactName { get; set; }

        [StringLength(50, ErrorMessage = "DealerBussinessName cannot exceed 50 characters.")]
        public string? DealerBussinessName { get; set; }

        [StringLength(50, ErrorMessage = "Address cannot exceed 50 characters.")]
        public string? Address { get; set; }

        [StringLength(150, ErrorMessage = "Email cannot exceed 150 characters.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string? Email { get; set; }

        [StringLength(50, ErrorMessage = "PhoneNumber cannot exceed 50 characters.")]
        public string? PhoneNumber { get; set; }

        [StringLength(50, ErrorMessage = "Mobile cannot exceed 50 characters.")]
        public string? Mobile1 { get; set; }

        [StringLength(50, ErrorMessage = "Mobile2 cannot exceed 50 characters.")]
        public string? Mobile2 { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "DueLimit must be a positive number.")]
        public decimal? DueLimit { get; set; }

        [StringLength(50, ErrorMessage = "Gread cannot exceed 50 characters.")]
        public string? Gread { get; set; }

        [StringLength(250, ErrorMessage = "CREATE_BY cannot exceed 250 characters.")]
        public string? CREATE_BY { get; set; }

        public DateTime? CREATE_DATE { get; set; }

        [StringLength(50, ErrorMessage = "UPDATE_BY cannot exceed 50 characters.")]
        public string? UPDATE_BY { get; set; }

        public DateTime? UPDATE_DATE { get; set; }

        public bool? InActive { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "AdvanceAmt must be a positive number.")]
        public decimal? AdvanceAmt { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "DueAmount must be a positive number.")]
        public decimal? DueAmount { get; set; }
    }
}
