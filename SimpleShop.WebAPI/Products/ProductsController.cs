using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Model.Products.Commands.CreateProducts;
using SimpleShop.Model.Products.Commands.DeleteProducts;
using SimpleShop.Model.Products.Commands.UpdateProducts;
using SimpleShop.Model.Products.Queries.FilterByCountId;
using SimpleShop.Model.Products.Queries.FilterByName;
using SimpleShop.WebAPI.Framework;

namespace SimpleShop.WebAPI.Products;

public class ProductsController : BaseController
{
	public ProductsController(IMediator mediator) : base(mediator)
	{
	}
	[HttpPost("CreateProduct")]
	public async Task<IActionResult> CreateProduct(CreateProductInput createProductInput)
	{
		var response = await _mediator.Send(createProductInput);
        
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
	}
    [HttpPut("UpdateProduct")]
    public async Task<IActionResult> UpdateProduct(UpdateProductInput updateProductInput)
    {
        var response = await _mediator.Send(updateProductInput);
        
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }
    [HttpGet("FilterByName")]
    public async Task<IActionResult> SearchProductByName([FromQuery] FilterByNameInput filterByNameInput)
    {
        var response = await _mediator.Send(filterByNameInput);
        
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }
    [HttpGet("FilterCountId")]
    public async Task<IActionResult> SearchProductByCountId([FromQuery] FilterByCountIdInput filterByCountIdInput)
    {
        var response = await _mediator.Send(filterByCountIdInput);

        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }
    [HttpDelete("DeleteProduct")]
    public async Task<IActionResult> DeleteProduct(DeleteProductInput deleteProductInput)
    {
        var response = await _mediator.Send(deleteProductInput);
        
        return response.IsSuccess ? Ok(response) : BadRequest(response.Errors);
    }
}
