using MediatR;
using SimpleShop.Model.Framework;
using SimpleShop.Model.Products.Entities;
using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Model.Products.Commands;

public class UpdateProduct : IRequest<ApplicationServiceResponse<Product>>
{
    [Required]
    [Range(1,int.MaxValue)]
    public int Id { get; set; }
    [Required]
    [StringLength(50,MinimumLength = 2)]
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public int CountId { get; set; }
}
