using log4net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.UseCases.Property.Queries.GetAll;
using System.Reflection;

namespace RealEstate.API.Controllers
{
    public class PropertyController : Controller
    {
        public readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.Name);
        public IMediator _mediator;
        
        public PropertyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("api/v1/properties")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllQuery()));
        }
    }
}
