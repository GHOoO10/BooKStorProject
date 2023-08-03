using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GhamdanAlYamaniProject.Models
{
    public class Books
    {
        [Key]
        public int B_Id { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(50)]
        public string B_Name { get; set;}
        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(70)]
        public string? B_Author { get; set; }
        [StringLength(50)]
        public string? B_Description { get; set;}
        public int B_Price { get; set; }
        public int A_Id { get; set; }
        [ForeignKey("A_Id")]
        public virtual Admin? Admins { get; set; }
        public int Cat_Id { get; set; }
        [ForeignKey("Cat_Id")]
        public virtual Catagory? Catagorys { get; set; }

        public virtual IEnumerable<Orders>? Order { get; set; }

        public virtual IEnumerable<BookStor>? BookStors { get; set; }




    }
}
