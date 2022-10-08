using MeufarmaceuticoApi.Contracts.Requests;
using MeufarmaceuticoApi.Contracts.Responses;
using MeufarmaceuticoApi.Mapping;
using MeufarmaceuticoApi.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace MeufarmaceuticoApi.Endpoints;

[HttpPost("customers"), AllowAnonymous]
public class CreateCustomerEndpoint : Endpoint<CreateCustomerRequest, CustomerResponse>
{
    private readonly ICustomerService _customerService;

    public CreateCustomerEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public override async Task HandleAsync(CreateCustomerRequest req, CancellationToken ct)
    {
        var customer = req.ToCustomer();

        await _customerService.CreateAsync(customer);

        var customerResponse = customer.ToCustomerResponse();
        await SendCreatedAtAsync<GetCustomerEndpoint>(
            new { Id = customer.Id.Value }, customerResponse, generateAbsoluteUrl: true, cancellation: ct);
    }
}
