using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Model.Counts.Commands;
using SimpleShop.Model.Counts.Queries;
using SimpleShop.WebAPI.Framework;

namespace SimpleShop.WebAPI.Counts;

public class CountsController : BaseController
{
	public CountsController(IMediator mediator) : base(mediator)
	{
	}
	[HttpPost("CreateCount")]
	public async Task<IActionResult> CreateCount(CreateCount count)
	{
		var response = await _mediator.Send(count);
        if (response.IsSuccess)
		{
			return Ok(response.Result);
		}
		return response.IsSuccess? Ok(response.Result): BadRequest(response.Errors);
    }
    [HttpPut("UpdateCount")]
    public async Task<IActionResult> UpdateCount(UpdateCount count)
    {
        var response = await _mediator.Send(count);
        if (response.IsSuccess)
        {
            return Ok(response.Result);
        }
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }
    [HttpGet("FilterByNameCo")]
    public async Task<IActionResult> SearchCount([FromQuery] FilterByNameCo count)
    {
        var response = await _mediator.Send(count);
        if (response.IsSuccess)
        {
            return Ok(response.Result);
        }
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }
    [HttpDelete("UpdateCount")]
    public async Task<IActionResult> DeleteCount(DeleteCount count)
    {
        var response = await _mediator.Send(count);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return response.IsSuccess ? Ok(response) : BadRequest(response.Errors);
    }
}
