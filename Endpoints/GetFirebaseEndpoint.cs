using MeufarmaceuticoApi.Contracts.Requests;
using MeufarmaceuticoApi.Contracts.Responses;
using MeufarmaceuticoApi.Mapping;
using MeufarmaceuticoApi.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.IO;
using System.Threading.Tasks;


namespace MeufarmaceuticoApi.Endpoints;

[HttpGet("firebase/{id:guid}"), AllowAnonymous]
public class GetFirebaseEndpoint : Endpoint<GetCustomerRequest, CustomerResponse>
{
    private readonly ICustomerService _customerService;

    public GetFirebaseEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public override async Task HandleAsync(GetCustomerRequest req, CancellationToken ct)
    {
        // var customer = await _customerService.GetAsync(req.Id);

        // if (customer is null)
        // {
        //     await SendNotFoundAsync(ct);
        //     return;
        // }

        // var customerResponse = customer.ToCustomerResponse();
        // await SendOkAsync(customerResponse, ct);

        
        var message = new Message()
        {
            Notification = new Notification
            {
                Title = "Message Title",
                Body = "Message Body"
            },
            Token = "AIzaSyCgl84EZpQBgq4rouGS2krzdGejPEseXOs",
            Topic = "news"
        };

        var messaging = FirebaseMessaging.DefaultInstance;
        var result = await messaging.SendAsync(message);
        
        Console.WriteLine(result);
    }
}
