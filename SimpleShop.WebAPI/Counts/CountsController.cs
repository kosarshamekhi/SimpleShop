using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Model.Counts.Commands.CreateCounts;
using SimpleShop.Model.Counts.Commands.DeleteCounts;
using SimpleShop.Model.Counts.Commands.UpdateCounts;
using SimpleShop.Model.Counts.Queries.FilterByName;
using SimpleShop.WebAPI.Framework;

namespace SimpleShop.WebAPI.Counts;

public class CountsController : BaseController
{
	public CountsController(IMediator mediator) : base(mediator)
	{
	}

    [HttpPost("CreateCount")]
    public async Task<IActionResult> CreateCount(CreateCountInput createCountInput)
    {
        var response = await _mediator.Send(createCountInput);

        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }
    [HttpPut("UpdateCount")]
    public async Task<IActionResult> UpdateCount(UpdateCountInput updateCountInput)
    {
        var response = await _mediator.Send(updateCountInput);
        
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }
    [HttpGet("FilterByName")]
    public async Task<IActionResult> SearchCount([FromQuery] FilterByNameInput filterByNameInput)
    {
        var response = await _mediator.Send(filterByNameInput);
        
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }
    [HttpDelete("DeleteCount")]
    public async Task<IActionResult> DeleteCount(DeleteCountInput deleteCountInput)
    {
        var response = await _mediator.Send(deleteCountInput);
        
        return response.IsSuccess ? Ok(response) : BadRequest(response.Errors);
    }
}
