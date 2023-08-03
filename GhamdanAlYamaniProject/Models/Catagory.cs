using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GhamdanAlYamaniProject.Models
{
    public class Catagory
    {
        [Key]
        public int Cat_Id { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Category Name")]

        public string? Cat_Name { get; set; }
        public virtual IEnumerable<Books>? Book { get; set; }
    }
}
