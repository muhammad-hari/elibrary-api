using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Moonlay.ELibrary.Domain.Models
{
    public partial class Book
    {
        public Book()
        {
            RentDetail = new HashSet<RentDetail>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Author { get; set; }
        public int PublisherId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<RentDetail> RentDetail { get; set; }
    }
}
