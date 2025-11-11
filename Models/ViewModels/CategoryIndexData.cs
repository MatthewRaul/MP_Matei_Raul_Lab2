using Lab2.Models;

namespace Matei_Raul_Lab2.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
        public int CategoryID { get; set; }
    }
}
