using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neoxim.Platform.Core.ValueObjects
{
    public class Address
    {
        public int Number { get; set; }
        public string Street { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}