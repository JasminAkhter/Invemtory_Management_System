using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.DTOs
{
    public class SalesReturnDTO
    {
        [Key]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal ID { get; set; }

        [StringLength(50, ErrorMessage = "ReturnInvoiceNo cannot exceed 50 characters.")]
        public string? ReturnInvoiceNo { get; set; }

        [StringLength(50, ErrorMessage = "InvoiceNo cannot exceed 50 characters.")]
        public string? InvoiceNo { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ReturnDate { get; set; }

        [StringLength(50, ErrorMessage = "ItemID cannot exceed 50 characters.")]
        [Unicode(false)]
        public string? ItemID { get; set; }

        [StringLength(50, ErrorMessage = "CustomerID cannot exceed 50 characters.")]
        public string? CustomerID { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "RQty must be a positive number.")]
        public decimal? RQty { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "SalesQty must be a positive number.")]
        public decimal? SalesQty { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "SalesPrice must be a positive number.")]
        public decimal? SalesPrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "TotalTotalPrice must be a positive number.")]
        public decimal? TotalTotalPrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "vat must be a positive number.")]
        public decimal? vat { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "NetAmount must be a positive number.")]
        public decimal? NetAmount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "ReturnAmount must be a positive number.")]
        public decimal? ReturnAmount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "CustomerPayment must be a positive number.")]
        public decimal? CustomerPayment { get; set; }

        [StringLength(50, ErrorMessage = "CreateBy cannot exceed 50 characters.")]
        public string? CreateBy { get; set; }

        public DateOnly? CreateDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
