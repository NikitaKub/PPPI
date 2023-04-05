using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PPPI.Models
{
    internal class Account
    {
        public string Type { get; set; } = "";
        public RemainingQuotas RemainingQuotas { get; set; }
    }
}
