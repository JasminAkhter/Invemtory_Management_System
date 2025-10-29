using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.DTOs
{
    public class UOMDTO
    {
        [Key]
        [StringLength(10, ErrorMessage = "UomID cannot exceed 10 characters.")]
        public string? UomID { get; set; }

        [Required(ErrorMessage = "UOMName is required.")]
        [StringLength(250, ErrorMessage = "UOMName cannot exceed 250 characters.")]
        public string? UOMName { get; set; }

        [StringLength(50, ErrorMessage = "Description cannot exceed 50 characters.")]
        public string? Description { get; set; }

        [StringLength(250, ErrorMessage = "CreateBy cannot exceed 250 characters.")]
        public string? CreateBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        [StringLength(250, ErrorMessage = "UpdateBy cannot exceed 250 characters.")]
        public string? UpdateBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
    }
}
