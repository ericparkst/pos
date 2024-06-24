using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Pos_backend_razor.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // This should be auto increment.

        [Required]
        [Range(201, 999)]
        [DisplayName("Category Code")]
        public required string CategoryCode { get; set; }

        [DisplayName("Category Name EN")]
        [MaxLength(100)]
        public required string NameEN { get; set; }

        [DisplayName("Category Name KO")]
        [MaxLength(100)]
        [Required]
        public required string NameKO { get; set; }

        [DisplayName("Department Code")]
        [Range(1, 9)]
        public required string DeptCode { get; set; }

    }
}
