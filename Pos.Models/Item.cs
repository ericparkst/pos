using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        // Define Range
        [Display(Name = "Item Code")]
        public string? ItemCode { get; set; }

        [Required]
        [DisplayName("Item Name EN")]
        public string? NameEN { get; set; }

        [Required]
        [DisplayName("Item Name KO")]
        public string? NameKO { get; set; }

        // Define Range
        [DisplayName("Department Code")]
        public string? DeptCode { get; set; }

        // Define Range
        [DisplayName("Category Code")]
        public string CategoryCode { get; set;}
        [ForeignKey("CategoryCode")]

        [ValidateNever]
        public Category? Category { get; set;}

        [ValidateNever]
        public string? Description { get; set; }

        [ValidateNever]
        public string? ImageUrl { get; set; }
    }
}
