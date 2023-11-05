using Negrea_Catalin_lab2.Models;
namespace Negrea_Catalin_lab2.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }

    }
}
