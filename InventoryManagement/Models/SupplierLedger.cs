#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Models;

public class SupplierLedger
{
    [Key]
    public int ID { get; set; }

    [StringLength(50)]
    public string SupplierId { get; set; }

    [StringLength(50)]
    public string ChallanNo { get; set; }

    [StringLength(50)]
    public string CustomerLedgerNo { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? BillAmt { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? PayAmt { get; set; }

    [StringLength(50)]
    public string PayModeID { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? AmountAdd { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? AmountOut { get; set; }

    [StringLength(50)]
    public string BankName { get; set; }

    [StringLength(50)]
    public string CHK_NO { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CheckDate { get; set; }

    [StringLength(50)]
    public string Reason { get; set; }

    [StringLength(50)]
    public string InvoiceNo { get; set; }

    [StringLength(550)]
    public string Comments { get; set; }

    [StringLength(50)]
    public string CreateBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateDate { get; set; }

    [StringLength(50)]
    public string UpdateBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }
}