using MediatR;
using SimpleShop.Model.Framework;
using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Model.Counts.Commands.DeleteCounts;

public class DeleteCountInput : IRequest<ApplicationServiceResponse>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int CountId { get; set; }
}

