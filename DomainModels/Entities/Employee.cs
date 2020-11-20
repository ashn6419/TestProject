using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Entities
{
    [Table("Employee")]
    public class Employee
    {
        public Employee()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name", TypeName = "varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please Enter Name!")]
        public string Name { get; set; }

        [Column("PhonenNumber")]
        [Required(ErrorMessage = "Please Enter Phone Number!")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter 10 digit mobile")]
        public long Phonenumber { get; set; }

        [Column("Email", TypeName = "varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please Enter Email!")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "InValid Email !")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Select Designation!")]
        public int DesignationId { get; set; }

        [Required(ErrorMessage = "Please Check Acitve!")]
        public bool Active { get; set; }
    }
}
