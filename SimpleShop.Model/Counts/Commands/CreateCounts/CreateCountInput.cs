using MediatR;
using SimpleShop.Model.Framework;
using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Model.Counts.Commands.CreateCounts;

public class CreateCountInput : IRequest<ApplicationServiceResponse<CreateCountOutput>>
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string CountName { get; set; }
}
