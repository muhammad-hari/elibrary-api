using System;
using System.Collections.Generic;
using System.Text;

namespace Moonlay.ELibrary.Data.Models
{
    public class DatabaseConnection
    {
        public string Development { get; set; }
        public string Staging { get; set; }
        public string Production { get; set; }
    }
}
