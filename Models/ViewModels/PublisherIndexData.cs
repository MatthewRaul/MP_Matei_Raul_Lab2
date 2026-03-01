using Lab2.Models;

namespace Matei_Raul_Lab2.Models.ViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers { get; set; }= new List<Publisher>();
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}
