using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Models;

public partial class CustomerLedger
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string CustomerId { get; set; }
    public string ChallanNo { get; set; }
    public string SupplierCompanyID { get; set; }
    public string CustomerLedgerNo { get; set; }
    public decimal? BillAmt { get; set; }
    public decimal? PayAmt { get; set; }
    public string PayModeID { get; set; }
    public string BankName { get; set; }
    public string CHK_NO { get; set; }
    public DateTime? CheckDate { get; set; }
    public string Reason { get; set; }
    public string InvoiceNo { get; set; }
    public string Comments { get; set; }
    public string CreateBy { get; set; }
    public DateTime? CreateDate { get; set; }
    public string UpdateBy { get; set; }
    public DateTime? UpdateDate { get; set; }
}