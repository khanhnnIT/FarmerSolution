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
        public int FarmerId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Username must be between 2 and 50 characters.")]
        [Column(TypeName = "varchar(50)")]
        public string FarmerCode { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Fullname must be between 1 and 50 characters.")]
        [Column(TypeName = "nvarchar(50)")]
        public string FarmerName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Fullname English must be between 1 and 50 characters.")]
        [Column(TypeName = "varchar(50)")]
        public string FarmerNameEN { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Address must be between 1 and 100 characters.")]
        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 characters.")]
        [Column(TypeName = "varchar(10)")]
        public string Phone1 { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 characters.")]
        [Column(TypeName = "varchar(10)")]
        public string Phone2 { get; set; }

        public DateTime InsertDate { get; set; } = DateTime.Now;
    }

}
