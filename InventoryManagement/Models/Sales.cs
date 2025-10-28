using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Models;

public class Sales
{
    [Key]
    public int SalesID { get; set; }

    [StringLength(50)]
    public string InvoiceNo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SalesDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SalesTime { get; set; }

    [StringLength(50)]
    public string OrderNo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OrderDate { get; set; }

    [StringLength(50)]
    public string ItemID { get; set; }

    [StringLength(550)]
    public string ProductInfo { get; set; }

    [StringLength(50)]
    public string PBarocde { get; set; }

    [StringLength(50)]
    public string CustomerID { get; set; }

    [StringLength(10)]
    public string SupplierCompanyID { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? SalesQty { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
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
    public decimal? vat { get; set; }

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

    [StringLength(50)]
    public string CreateBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateDate { get; set; }

    [StringLength(50)]
    public string UpdateBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public bool? IsSalesVoid { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? CustomerPerviousDue { get; set; }

    public bool? IsFree { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? NetSalesAmount { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? ConeQty { get; set; }
}