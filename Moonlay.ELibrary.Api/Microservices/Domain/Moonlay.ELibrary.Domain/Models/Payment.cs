using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Moonlay.ELibrary.Domain.Models
{
    public partial class Payment
    {
        public Payment()
        {
            RentDetail = new HashSet<RentDetail>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int AdminId { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<RentDetail> RentDetail { get; set; }
    }
}
