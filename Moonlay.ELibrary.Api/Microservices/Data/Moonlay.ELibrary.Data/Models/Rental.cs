using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Moonlay.ELibrary.Data.Models
{
    public partial class Rental
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int BookId { get; set; }
        public DateTime DateOfReturn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Book Book { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
