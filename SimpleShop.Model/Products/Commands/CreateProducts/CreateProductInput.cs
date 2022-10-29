using MediatR;
using SimpleShop.Model.Framework;
using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Model.Products.Commands.CreateProducts;

public class CreateProductInput : IRequest<ApplicationServiceResponse<CreateProductOutput>>
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public int CountId { get; set; }
}
