using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using PPPI;


public class PPPIServerAPI
{
    static HttpClient httpClient = new HttpClient();
    static Model model = new Model();

    static async Task Main()
    {

        await GetAsync();

        await StatusSite();

        await PostAsync();

        await StatusSite();

        Console.WriteLine("All Types which used");
        foreach(var item in model.List)
        {
            Console.WriteLine(item.Type);
        }
    }

    static async Task SetUrl(string url)
    {
        model.Message = await httpClient.GetAsync($"{url}");
    }

    static async Task GetAsync()
    {
        await SetUrl("https://api.geneea.com/account");
        if (model.Message.StatusCode == HttpStatusCode.OK)
        {
            Account account = await model.Message.Content.ReadFromJsonAsync<Account>();
            Console.WriteLine("Type: " + account.Type + " | Remaining Quotas: {Hits: " + account.RemainingQuotas.Hits + " | Characters: " + account.RemainingQuotas.Characters + "}");
            model.addToList(account);
        }
        else
        {
            await model.Message.Content.ReadFromJsonAsync<Model>();
            Console.WriteLine(model.Error);
        }
    }

    static async Task PostAsync()
    {
        await SetUrl("https://api.geneea.com/account?user_key=6d972176d8a0638756be17d6bc9ceb57");
        if (model.Message.StatusCode == HttpStatusCode.OK)
        {
            Account account = await model.Message.Content.ReadFromJsonAsync<Account>();
            Console.WriteLine("Type: " + account.Type + " | Remaining Quotas: {Hits: " + account.RemainingQuotas.Hits + " | Characters: " + account.RemainingQuotas.Characters + "}");
            model.addToList(account);
        }
        else
        {
            await model.Message.Content.ReadFromJsonAsync<Model>();
            Console.WriteLine(model.Error);
        }
    }

    static async Task StatusSite()
    {
        if (model.Message.IsSuccessStatusCode == true)
        {
            Console.WriteLine("Status True");
        }
        else
        {
            Console.WriteLine("Status False");
        }
        model.StatusCode = model.Message.StatusCode;
    }

}