using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PPPI
{
    internal class Model
    {
        private HttpResponseMessage message;
        private HttpStatusCode statusCode;
        private List<Account> list = new List<Account>();

        public HttpResponseMessage Message { get { return message; } set { message = value; } }
        public HttpStatusCode StatusCode { get { return statusCode; } set { statusCode = value;} }
        public List<Account> List { get { return list; } set { list = value;} }

        public void addToList(Account account)
        {
            list.Add(account);
        }

        public string Error { get; set; }
    }



    internal class Account
    {
        public string Type { get; set; } = "";
        public RemainingQuotas RemainingQuotas { get; set; }
    }
    
    internal class RemainingQuotas
    {
        public int Hits { get; set; }
        public int Characters { get; set; }
    }

}
