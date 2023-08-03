using System.ComponentModel.DataAnnotations;

namespace GhamdanAlYamaniProject.Models
{
    public class Admin
    {
        [Key]
        public int A_Id { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string? A_Name { get; set; }
        [StringLength(40)]
        public string A_Email { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Email Admin")]


        public string A_Password { get; set; }
        //[DataType(DataType.Password)]


    }
}
