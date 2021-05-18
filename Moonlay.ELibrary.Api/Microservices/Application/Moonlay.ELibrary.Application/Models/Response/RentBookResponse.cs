using Moonlay.ELibrary.Application.Models;
using System;
using System.Collections.Generic;

namespace Moonlay.ELibrary.Application.Models.Response
{
    public class RentBookResponse
    {
       public string CustomerName { get; set; }
       public string EmployeeName { get; set; }
       public List<RentalDto> Data { get; set; }
       public DateTime TransactionDate { get; set; }
       public decimal TotalCost { get; set; }
    }
}
