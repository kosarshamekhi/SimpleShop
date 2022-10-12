using MediatR;
using SimpleShop.Model.Framework;
using SimpleShop.Model.Products.Entities;
using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Model.Products.Commands;

public class CreateProduct:IRequest<ApplicationServiceResponse<Product>>
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public int CountId { get; set; }
}
