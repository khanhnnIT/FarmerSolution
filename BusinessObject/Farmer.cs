using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Farmer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public Guid FarmerId { get; set; }

        [Required(ErrorMessage = "Please enter Farmer Code!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Username must be between 2 and 50 characters.")]
        [Column(TypeName = "varchar(50)")]
        public string FarmerCode { get; set; }

        [Required(ErrorMessage = "Please enter Farmer Name!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Fullname must be between 1 and 50 characters.")]
        [Column(TypeName = "nvarchar(50)")]
        public string FarmerName { get; set; }

        [Required(ErrorMessage = "Please enter Farmer Name in English!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Fullname English must be between 1 and 50 characters.")]
        [Column(TypeName = "varchar(50)")]
        public string FarmerNameEN { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Address { get; set; }

        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Phone 1 must have 10 digits and start with 0")]
        [Column(TypeName = "varchar(10)")]
        public string? Phone1 { get; set; }

        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Phone 2 must have 10 digits and start with 0")]
        [Column(TypeName = "varchar(10)")]
        public string? Phone2 { get; set; }

        public DateTime? InsertDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }

}
