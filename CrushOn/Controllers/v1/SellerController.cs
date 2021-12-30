using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CrushOn.API.Controllers;
using CrushOn.Application.Commands;
using CrushOn.Core.EntitiesModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static CreateSellerHandler;

[Route("api/v1/seller")]
[ApiController]
public class SellerController : CrushOnController
{
    private readonly IMediator _mediator;

    public SellerController(IMediator mediator)
    {
        _mediator = mediator;
    }


    /// <summary>
    /// Create new seller
    /// </summary>
    /// <param name="userRole"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("createSeller/{userRole}")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
    [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
    public async Task<IActionResult> CreateNewSeller(int userRole, [FromBody] CreateSellerCommand command)
    {
        if (!ModelState.IsValid)
            return null;

        if (userRole != 1)
        {
            ModelState.AddModelError("User Role", "Can't add new seller. Need to be super admin");
            return BadRequest(ModelState);
        }

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    /// <summary>
    /// Get all sellers 
    /// </summary>
    /// <param name="userRole"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getAll/{userRole}")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
    [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
    public async Task<IActionResult> GetAll(int userRole)
    {
        if (!ModelState.IsValid)
            return null;

        if (userRole != 1)
        {
            ModelState.AddModelError("User Role", "Can't access to this feature. Need to be super admin");
            return BadRequest(ModelState);
        }

        var t = await _mediator.Send(new SellerModel());

        return Ok(t);
    }
}