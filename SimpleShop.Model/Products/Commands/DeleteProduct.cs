using MediatR;
using SimpleShop.Model.Framework;
using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Model.Products.Commands;

public class DeleteProduct : IRequest<ApplicationServiceResponse>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
}
