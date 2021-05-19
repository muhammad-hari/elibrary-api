using System;
using System.Collections.Generic;
using System.Text;

namespace Moonlay.ELibrary.WebClient.Models.Request
{
    public class BookItems
    {
        public int BookID { get; set; }
        public decimal Cost { get; set; }
        public DateTime DateOfBorrow { get; set; }
        public DateTime DateOfReturn { get; set; }

    }
}
