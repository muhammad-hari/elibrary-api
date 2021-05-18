using System;

namespace Moonlay.ELibrary.Application.Models
{
    public class RentalDto
    {
        public DateTime DateOfReturn { get; set; }
        public DateTime DateOfBorrow { get; set; }
        public decimal Cost { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public BookDto Book { get; set; }
    }
}
