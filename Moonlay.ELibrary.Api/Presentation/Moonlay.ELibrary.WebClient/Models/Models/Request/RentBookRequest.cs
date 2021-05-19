using System;
using System.Collections.Generic;

namespace Moonlay.ELibrary.WebClient.Models.Request
{
    public class RentBookRequest
    {
        public int AdminID { get; set; }
        public int CustomerID { get; set; }
        public List<BookItems> BookItems { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
