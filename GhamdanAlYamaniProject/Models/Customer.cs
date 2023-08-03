using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GhamdanAlYamaniProject.Models
{
    public class Customer
    {
        [Key]
        public int C_Id { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
      
        public string C_Name { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Customer Name")]
        [StringLength(100, ErrorMessage = "Must smaller then 100")]
        
        public string C_Email { get; set; }
        [Required(ErrorMessage = "This Field is Required")]

        public int C_Phone { get; set; }
        
        public string? C_Address { get; set; }

        public virtual IEnumerable<Orders>? Order { get; set; }

    }
}
