using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Moonlay.ELibrary.Domain.Models
{
    public partial class RentDetail
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public int BookId { get; set; }
        public DateTime DateOfReturn { get; set; }
        public DateTime DateOfBorrow { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal Cost { get; set; }
        public virtual Book Book { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
