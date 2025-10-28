using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.DTOs
{
    public class CustomerLedgerDTO
    {
        public int ID { get; set; } 

        [StringLength(50, ErrorMessage = "CustomerId cannot exceed 50 characters.")]
        public string CustomerId { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "ChallanNo cannot exceed 50 characters.")]
        public string? ChallanNo { get; set; }

        [StringLength(50, ErrorMessage = "SupplierCompanyID cannot exceed 50 characters.")]
        public string? SupplierCompanyID { get; set; }

        [StringLength(50, ErrorMessage = "CustomerLedgerNo cannot exceed 50 characters.")]
        public string? CustomerLedgerNo { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "BillAmt must be a positive value.")]
        public decimal? BillAmt { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "PayAmt must be a positive value.")]
        public decimal? PayAmt { get; set; }

        [StringLength(50, ErrorMessage = "PayModeID cannot exceed 50 characters.")]
        public string? PayModeID { get; set; }

        [StringLength(50, ErrorMessage = "BankName cannot exceed 50 characters.")]
        public string? BankName { get; set; }

        [StringLength(50, ErrorMessage = "CHK_NO cannot exceed 50 characters.")]
        public string? CHK_NO { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CheckDate { get; set; }

        [StringLength(50, ErrorMessage = "Reason cannot exceed 50 characters.")]
        public string? Reason { get; set; }

        [StringLength(50, ErrorMessage = "InvoiceNo cannot exceed 50 characters.")]
        public string? InvoiceNo { get; set; }

        [StringLength(550, ErrorMessage = "Comments cannot exceed 550 characters.")]
        public string? Comments { get; set; }

        [StringLength(50, ErrorMessage = "CreateBy cannot exceed 50 characters.")]
        public string? CreateBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        [StringLength(50, ErrorMessage = "UpdateBy cannot exceed 50 characters.")]
        public string? UpdateBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
    }
}
