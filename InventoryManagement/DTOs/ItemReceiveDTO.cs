using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.DTOs
{
    public class ItemReceiveDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "ChalanNo is required.")]
        [StringLength(50, ErrorMessage = "ChalanNo cannot exceed 50 characters.")]
        public string? ChalanNo { get; set; }

        [Required(ErrorMessage = "SupplierCompanyID is required.")]
        [StringLength(50, ErrorMessage = "SupplierCompanyID cannot exceed 50 characters.")]
        public string? SupplierCompanyID { get; set; }

        [Required(ErrorMessage = "ItemID is required.")]
        [StringLength(50, ErrorMessage = "ItemID cannot exceed 50 characters.")]
        public string? ItemID { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "PurchasePrice must be a positive number.")]
        public decimal? PurchasePrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalPurchasePrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "SalesPrice must be a positive number.")]
        public decimal? SalesPrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalSalesPrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? WholeSalesPrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, 100, ErrorMessage = "DiscountPercent must be between 0 and 100.")]
        public decimal? DiscountPercent { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TradePrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, 100, ErrorMessage = "ProfitPercent must be between 0 and 100.")]
        public decimal? ProfitPercent { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ProfitAmt { get; set; }

        public DateOnly? ReceiveDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "ReceiveQTY must be a positive number.")]
        public decimal? ReceiveQTY { get; set; }

        public int? TotalRecQty { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        [Range(0, double.MaxValue, ErrorMessage = "TotalAmount must be a positive number.")]
        public decimal? TotalAmount { get; set; }

        [StringLength(550, ErrorMessage = "ItemInfo cannot exceed 550 characters.")]
        public string? ItemInfo { get; set; }

        [StringLength(150)]
        public string? CreateBy { get; set; }

        public DateOnly? CreateDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [StringLength(150)]
        public string? UpdateBy { get; set; }

        public DateOnly? UpdateDate { get; set; }

        [StringLength(50)]
        public string? MemoNo { get; set; }
    }
}
