using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.DTOs
{

    public class SupplierLedgerDTO
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(50, ErrorMessage = "SupplierId cannot exceed 50 characters.")]
        public string? SupplierId { get; set; }

        [StringLength(50, ErrorMessage = "ChallanNo cannot exceed 50 characters.")]
        public string? ChallanNo { get; set; }

        [StringLength(50, ErrorMessage = "CustomerLedgerNo cannot exceed 50 characters.")]
        public string? CustomerLedgerNo { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "BillAmt must be a positive number.")]
        public decimal? BillAmt { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "PayAmt must be a positive number.")]
        public decimal? PayAmt { get; set; }

        [StringLength(50, ErrorMessage = "PayModeID cannot exceed 50 characters.")]
        public string? PayModeID { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "AmountAdd must be a positive number.")]
        public decimal? AmountAdd { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "AmountOut must be a positive number.")]
        public decimal? AmountOut { get; set; }

        [StringLength(50, ErrorMessage = "BankName cannot exceed 50 characters.")]
        public string? BankName { get; set; }

        [StringLength(50, ErrorMessage = "CHK_NO cannot exceed 50 characters.")]
        public string? CHK_NO { get; set; }

        public DateTime? CheckDate { get; set; }

        [StringLength(50, ErrorMessage = "Reason cannot exceed 50 characters.")]
        public string? Reason { get; set; }

        [StringLength(50, ErrorMessage = "InvoiceNo cannot exceed 50 characters.")]
        public string? InvoiceNo { get; set; }

        [StringLength(550, ErrorMessage = "Comments cannot exceed 550 characters.")]
        public string? Comments { get; set; }

        [StringLength(50, ErrorMessage = "CreateBy cannot exceed 50 characters.")]
        public string? CreateBy { get; set; }

        public DateTime? CreateDate { get; set; } = DateTime.Now;

        [StringLength(50, ErrorMessage = "UpdateBy cannot exceed 50 characters.")]
        public string? UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; } = DateTime.Now;
    }

}

