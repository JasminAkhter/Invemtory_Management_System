using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Models;

public class Category
{
    [Key]
    [StringLength(50)]
    public string CategoryID { get; set; }

    [Required]
    [StringLength(250)]
    public string CategoryName { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Vat { get; set; }

    [StringLength(250)]
    public string? CreateBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateDate { get; set; }

    [StringLength(250)]
    public string? UpdateBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Item> Item { get; set; } = new List<Item>();
}
