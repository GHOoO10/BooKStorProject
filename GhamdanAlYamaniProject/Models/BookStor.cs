using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GhamdanAlYamaniProject.Models
{
    public class BookStor
    {
        [Key]
        public int BS_Id { get; set; }
        [Required]

        public int BS_Num { get; set; }

        public int BS_Type { get; set; }

        public DateTime BS_Date { get; set; } = DateTime.Now;

        public int B_Id { get; set; }
        [ForeignKey("B_Id")]
        public virtual Books? Book { get; set; }

    }
}
