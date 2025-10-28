using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Models;

public class CustomerSetup
{
    [Key]
    public string CustomerID { get; set; }

    [Required]

    public string CustomerName { get; set; }

    public string ContactName { get; set; }

    public string DealerBussinessName { get; set; }

    public string Address { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Mobile1 { get; set; }

    public string Mobile2 { get; set; }

    public decimal? DueLimit { get; set; }

    public string? Gread { get; set; }

    public string? CREATE_BY { get; set; }

    public DateTime? CREATE_DATE { get; set; }

    public string? UPDATE_BY { get; set; }

    public DateTime? UPDATE_DATE { get; set; }

    public bool? InActive { get; set; }

    public decimal? AdvanceAmt { get; set; }

    
    public decimal? DueAmount { get; set; }
}