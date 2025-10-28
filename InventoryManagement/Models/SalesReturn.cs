using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Models;

public partial class SalesReturn
{
    [Key]
    [Column(TypeName = "decimal(18, 0)")]
    public decimal ID { get; set; }

    [StringLength(50)]
    public string ReturnInvoiceNo { get; set; }

    [StringLength(50)]
    public string InvoiceNo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReturnDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ItemID { get; set; }

    [StringLength(50)]
    public string CustomerID { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? RQty { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? SalesQty { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? SalesPrice { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TotalTotalPrice { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? vat { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? NetAmount { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? ReturnAmount { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? CustomerPayment { get; set; }

    [StringLength(50)]
    public string CreateBy { get; set; }

    public DateOnly? CreateDate { get; set; }
}