using MediatR;
using SimpleShop.Model.Framework;
using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Model.Products.Commands.UpdateProducts;

public class UpdateProductInput : IRequest<ApplicationServiceResponse<UpdateProductOutputt>>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public int CountId { get; set; }
}
