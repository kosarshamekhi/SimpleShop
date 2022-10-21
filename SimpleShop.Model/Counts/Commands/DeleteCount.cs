using MediatR;
using SimpleShop.Model.Framework;
using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Model.Counts.Commands;

public class DeleteCount : IRequest<ApplicationServiceResponse>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
}
