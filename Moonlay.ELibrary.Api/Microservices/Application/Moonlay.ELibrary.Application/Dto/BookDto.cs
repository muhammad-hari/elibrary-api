using System;

namespace Moonlay.ELibrary.Application.Models
{
    public class BookDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string PublisherName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
