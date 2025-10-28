using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.DTOs
{
    public class ItemDTO
    {
        [Key]
        [StringLength(50, ErrorMessage = "Item_Id cannot exceed 50 characters.")]
        public string Item_Id { get; set; } = string.Empty;

        [Required(ErrorMessage = "ItemName is required.")]
        [StringLength(550, ErrorMessage = "ItemName cannot exceed 550 characters.")]
        public string ItemName { get; set; } = string.Empty;


        [StringLength(10, ErrorMessage = "CategoryID cannot exceed 10 characters.")]
        public string? CategoryID { get; set; }


        [StringLength(10, ErrorMessage = "ModelID cannot exceed 10 characters.")]
        public string? ModelID { get; set; }


        [StringLength(10, ErrorMessage = "BrandID cannot exceed 10 characters.")]
        public string? BrandID { get; set; }


        [StringLength(10, ErrorMessage = "SizeID cannot exceed 10 characters.")]
        public string? SizeID { get; set; }


        [StringLength(50, ErrorMessage = "ColorID cannot exceed 50 characters.")]
        public string? ColorID { get; set; }


        [StringLength(10, ErrorMessage = "UomID cannot exceed 10 characters.")]
        public string? UomID { get; set; }


        [StringLength(50, ErrorMessage = "SupplierCompanyID cannot exceed 50 characters.")]
        public string? SupplierCompanyID { get; set; }


        [StringLength(50, ErrorMessage = "ProductBarcode cannot exceed 50 characters.")]
        public string? ProductBarcode { get; set; }


        [StringLength(50, ErrorMessage = "BarCode1 cannot exceed 50 characters.")]
        public string? BarCode1 { get; set; }


        [StringLength(50, ErrorMessage = "Barcode2 cannot exceed 50 characters.")]
        public string? Barcode2 { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "PurchasePrice must be a positive number.")]
        public decimal? PurchasePrice { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "SalesPrice must be a positive number.")]
        public decimal? SalesPrice { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "WholeSalesPrice must be a positive number.")]
        public decimal? WholeSalesPrice { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, 100, ErrorMessage = "DiscountPersent must be between 0 and 100.")]
        public decimal? DiscountPersent { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "TradePrice must be a positive number.")]
        public decimal? TradePrice { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, 100, ErrorMessage = "ProfitPersent must be between 0 and 100.")]
        public decimal? ProfitPersent { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "ProfitAmt must be a positive number.")]
        public decimal? ProfitAmt { get; set; }


        [StringLength(250, ErrorMessage = "CREATE_BY cannot exceed 250 characters.")]
        public string? CREATE_BY { get; set; }


        public DateTime? CREATE_DATE { get; set; } = DateTime.Now;


        [StringLength(50, ErrorMessage = "UPDATE_BY cannot exceed 50 characters.")]
        public string? UPDATE_BY { get; set; }


        public DateTime? UPDATE_DATE { get; set; }

        public bool? InActive { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "OpeningStock must be a positive number.")]
        public decimal? OpeningStock { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "MinimumAlertQty must be a positive integer.")]
        public int? MinimumAlertQty { get; set; }
    }
}
