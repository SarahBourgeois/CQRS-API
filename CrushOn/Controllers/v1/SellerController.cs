using System;
using System.Net;
using System.Threading.Tasks;
using CrushOn.API.Controllers;
using CrushOn.Core.Entities;
using CrushOn.Infrastructure.Abstract.Business.Seller;
using CrushOn.Infrastructure.Abstract.Response;
using Microsoft.AspNetCore.Mvc;


namespace CrushOn.API.Controllers.v1
{
    [Produces("application/json")]
    [ApiController]
    [Route("[v1/seller]")]
    public class SellerController : CrushOnController
    {
        private readonly IServiceResponseWrapper _serviceResponseWrapper;
        private readonly ISellerBusiness _sellerBusiness;

        /// <summary>
        /// Create new seller for the current logged-in user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [Route("create/{userRole}")]
        public async Task<IActionResult> CreateNewSellerAsync(int userRole, SellerDto sellerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (userRole != 1)
                {
                    ModelState.AddModelError("User Role", "Can't access to this feature. Need to be super admin");
                    return BadRequest(ModelState);
                }
                
                SellerModel response = await _sellerBusiness.CreateNewSellerAsync(sellerDto);

                return Ok(response);
            }
            catch (Exception e)
            {
                return HandleErrorResponse(_serviceResponseWrapper.Wrap<object>(null, false, false, errorMessage: Convert.ToString(e)));
            }
        }
    }
}
