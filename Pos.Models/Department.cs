using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Pos.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Range(1, 9)]
        [DisplayName("Department Code")]

        public string? DeptCode { get; set; }

        [DisplayName("Department Name EN")]
        public  string? NameEN { get; set; }

        [DisplayName("Department Name KO")]
        public string? NameKO { get; set; }

        [ValidateNever]
        public string? Description { get; set; }

        [ValidateNever]
        public string? ImageUrl { get; set; }
    }
}
