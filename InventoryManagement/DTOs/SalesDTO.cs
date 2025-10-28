using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.DTOs
{
    public class SalesDTO
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesID { get; set; }

        [StringLength(50, ErrorMessage = "InvoiceNo cannot exceed 50 characters.")]
        public string? InvoiceNo { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? SalesDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? SalesTime { get; set; }

        [StringLength(50, ErrorMessage = "OrderNo cannot exceed 50 characters.")]
        public string? OrderNo { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }

        [StringLength(50, ErrorMessage = "ItemID cannot exceed 50 characters.")]
        public string? ItemID { get; set; }

        [StringLength(550, ErrorMessage = "ProductInfo cannot exceed 550 characters.")]
        public string? ProductInfo { get; set; }

        [StringLength(50, ErrorMessage = "PBarcode cannot exceed 50 characters.")]
        public string? PBarocde { get; set; }

        [StringLength(50, ErrorMessage = "CustomerID cannot exceed 50 characters.")]
        public string? CustomerID { get; set; }

        [StringLength(10, ErrorMessage = "SupplierCompanyID cannot exceed 10 characters.")]
        public string? SupplierCompanyID { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue)]
        public decimal? SalesQty { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue)]
        public decimal? SalesReturnQty { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? MRP { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalMRP { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? SalesPrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalSalesPrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PurchasePrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalPurchasePrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ItemVatPercent { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Vat { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? DiscountPercentPerItem { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? DiscountAmountPerItem { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalDiscountAmt { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ChargeAmount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? NetAmount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PaidAmount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ReturnAmount { get; set; }

        [StringLength(50, ErrorMessage = "CreateBy cannot exceed 50 characters.")]
        public string? CreateBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        [StringLength(50, ErrorMessage = "UpdateBy cannot exceed 50 characters.")]
        public string? UpdateBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; } = DateTime.Now;

        public bool? IsSalesVoid { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? CustomerPreviousDue { get; set; }

        public bool? IsFree { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? NetSalesAmount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ConeQty { get; set; }
    }
}
