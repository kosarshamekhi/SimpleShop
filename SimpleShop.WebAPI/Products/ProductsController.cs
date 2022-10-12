using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Model.Products.Commands;
using SimpleShop.Model.Products.Queries;
using SimpleShop.WebAPI.Framework;

namespace SimpleShop.WebAPI.Products;

public class ProductsController : BaseController
{
	public ProductsController(IMediator mediator) : base(mediator)
	{
	}
	[HttpPost("CreateProduct")]
	public async Task<IActionResult> CreateProduct(CreateProduct product)
	{
		var response = await _mediator.Send(product);
        
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
	}
    [HttpPut("UpdateProduct")]
    public async Task<IActionResult> UpdateProduct(UpdateProduct product)
    {
        var response = await _mediator.Send(product);
        
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }
    [HttpGet("FilterByNamePr")]
    public async Task<IActionResult> SearchCount([FromQuery] FilterByNamePr product)
    {
        var response = await _mediator.Send(product);
        if (response.IsSuccess)
        {
            return Ok(response.Result);
        }
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }
}
