using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using PPPI.Controller;
using PPPI.Models;

public class PPPIServerAPI
{

    static async Task Main()
    {
        HTTPClientCustomable hTTPClientCustomable = new HTTPClientCustomable();

        await hTTPClientCustomable.GetAsync();

        await hTTPClientCustomable.StatusSite();

        await hTTPClientCustomable.PostAsync();

        await hTTPClientCustomable.StatusSite();

        // Generic List which contain all data whose we gathered from API
        Console.WriteLine("All Types which used");
        foreach(var item in hTTPClientCustomable.List)
        {
            Console.WriteLine(item.Type);
        }
    }
}