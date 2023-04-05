using PPPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PPPI.Controller
{
    internal class HTTPClientCustomable
    {
        public HttpResponseMessage Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public List<Account> List { get; set; } = new List<Account>();
        public HttpClient HttpClient { get; set; } = new HttpClient();
        public string Error { get; set; }

        public void addToList(Account account)
        {
            List.Add(account);
        }

        public async Task SetUrl(string url)
        {
            Message = await HttpClient.GetAsync($"{url}");
        }

        public async Task GetAsync()
        {
            try
            {
                await SetUrl("https://api.geneea.com/account");
                Account account = await Message.Content.ReadFromJsonAsync<Account>();
                Console.WriteLine("Type: " + account.Type + " | Remaining Quotas: {Hits: " + account.RemainingQuotas.Hits + " | Characters: " + account.RemainingQuotas.Characters + "}");
                addToList(account);

            }
            catch(Exception ex) when(Message.StatusCode != HttpStatusCode.OK)
            {
                await Message.Content.ReadFromJsonAsync<HTTPClientCustomable>();
                Console.WriteLine(Error);
                if (ex.StackTrace != "") Console.WriteLine(ex.StackTrace);
            }
        }

        public async Task PostAsync()
        {
            try
            {
                await SetUrl("https://api.geneea.com/account?user_key=6d972176d8a0638756be17d6bc9ceb57");
                Account account = await Message.Content.ReadFromJsonAsync<Account>();
                Console.WriteLine("Type: " + account.Type + " | Remaining Quotas: {Hits: " + account.RemainingQuotas.Hits + " | Characters: " + account.RemainingQuotas.Characters + "}");
                addToList(account);

            }
            catch (Exception ex) when (Message.StatusCode != HttpStatusCode.OK)
            {
                await Message.Content.ReadFromJsonAsync<HTTPClientCustomable>();
                Console.WriteLine(Error);
                if (ex.StackTrace != "") Console.WriteLine(ex.StackTrace);
            }
        }

        public async Task StatusSite()
        {
            if (Message.IsSuccessStatusCode == true)
            {
                Console.WriteLine("Status True");
            }
            else
            {
                Console.WriteLine("Status False");
            }
            StatusCode = Message.StatusCode;
        }
    }
}
