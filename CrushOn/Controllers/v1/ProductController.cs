using System;
using System.Net;
using System.Threading.Tasks;
using CrushOn.API.Controllers;
using CrushOn.Application.Commands;
using CrushOn.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/v1/products")]
[ApiController]
public class ProductController : CrushOnController
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Add new product 
    /// </summary>
    /// <param name="userRole"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("addProduct/{userRole}")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
    [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
    public async Task<IActionResult> CreateNewSeller(int userRole, [FromBody] CreateSellerCommand command)
    {
        if (!ModelState.IsValid)
            return null;

        if (userRole != (int)UserRole.Seller)
        {
            ModelState.AddModelError("User Role", "Can't add new seller. Need to be seller");
            return Forbid();
        }

        var result = await _mediator.Send(command);

        return Ok(result);
    }
}


