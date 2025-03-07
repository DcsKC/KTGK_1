using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTGK_1.Models
{
    [Table("Goods")]
    public class hang_hoa
    {
        [Key]
        [StringLength(9, MinimumLength = 9)]
        public string ma_hanghoa { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(max)")] 
        public string ten_hanghoa { get; set; } = string.Empty;

        public int so_luong { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? ghi_chu { get; set; }
    }
}
