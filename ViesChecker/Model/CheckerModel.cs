using System;
using System.Collections.Generic;
using System.Text;

namespace ViesChecker.Model
{
    public class CheckerModel
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string VatNumber { get; set; }
        
        public string CountryCode { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsValid { get; set; }
    }
}

