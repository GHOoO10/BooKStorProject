using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GhamdanAlYamaniProject.Models
{
    public class Orders
    {
        [Key]
        public int O_Id { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string? O_Data { get; set; }
        public int O_Amount { get; set; }
        [Required(ErrorMessage = "This Field is Required and Number")]

        public int B_Id { get; set; }
        [ForeignKey("B_Id")]
        public virtual Books? Book { get; set; }
        public int C_Id { get; set; }
        [ForeignKey("C_Id")]
        public virtual Customer? Customers { get; set; }


    }
}
