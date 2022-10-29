using MediatR;
using SimpleShop.Model.Framework;
using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Model.Products.Commands.DeleteProducts;

public class DeleteProductInput : IRequest<ApplicationServiceResponse>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }

}
