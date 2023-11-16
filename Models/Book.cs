using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Negrea_Catalin_lab2.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Required]
        [StringLength(150, MinimumLength =3)]
        [Display(Name = "Book Title")]
        public string Title { get; set; }
        public int? AuthorID { get; set; }
        public Authors? Author { get; set; }

        public string AuthorName => Author?.FirstName + " " + Author?.LastName;
        [Column(TypeName = "decimal(6, 2")]
        [Range(0.01, 500)]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }
        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; }
        public int? BorrowingID { get; set; }
        public Borrowing? Borrowing { get; set; }
        public ICollection<BookCategory>? BookCategories { get; set; }

    }
}
