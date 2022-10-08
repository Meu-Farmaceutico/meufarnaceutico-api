using MeufarmaceuticoApi.Contracts.Requests;
using MeufarmaceuticoApi.Contracts.Responses;
using MeufarmaceuticoApi.Mapping;
using MeufarmaceuticoApi.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace MeufarmaceuticoApi.Endpoints;

[HttpPut("customers/{id:guid}"), AllowAnonymous]
public class UpdateCustomerEndpoint : Endpoint<UpdateCustomerRequest, CustomerResponse>
{
    private readonly ICustomerService _customerService;

    public UpdateCustomerEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public override async Task HandleAsync(UpdateCustomerRequest req, CancellationToken ct)
    {
        var existingCustomer = await _customerService.GetAsync(req.Id);

        if (existingCustomer is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var customer = req.ToCustomer();
        await _customerService.UpdateAsync(customer);

        var customerResponse = customer.ToCustomerResponse();
        await SendOkAsync(customerResponse, ct);
    }
}
