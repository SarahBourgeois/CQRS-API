using System;
using System.Collections.Generic;
using System.Linq;
using CrushOn.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace CrushOn.Controllers
{
    [ApiController]
    [Route("[v1/seller ]")]
    public class SellerController : ControllerBase
    {
        private readonly ILogger<SellerController> _logger;


        /// <summary>
        /// Create new seller for the current logged-in user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("create/{memberRole}")]
        public IEnumerable<Seller> CreateNewSeller()
        {
         
        }
    }
}
