﻿using MeufarmaceuticoApi.Contracts.Requests;
using MeufarmaceuticoApi.Contracts.Responses;
using MeufarmaceuticoApi.Mapping;
using MeufarmaceuticoApi.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace MeufarmaceuticoApi.Endpoints;

[HttpGet("customers/{id:guid}"), AllowAnonymous]
public class GetCustomerEndpoint : Endpoint<GetCustomerRequest, CustomerResponse>
{
    private readonly ICustomerService _customerService;

    public GetCustomerEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public override async Task HandleAsync(GetCustomerRequest req, CancellationToken ct)
    {
        var customer = await _customerService.GetAsync(req.Id);

        if (customer is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var customerResponse = customer.ToCustomerResponse();
        await SendOkAsync(customerResponse, ct);
    }
}
