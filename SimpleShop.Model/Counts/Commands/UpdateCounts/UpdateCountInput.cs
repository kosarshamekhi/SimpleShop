using MediatR;
using SimpleShop.Model.Framework;
using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Model.Counts.Commands.UpdateCounts;

public class UpdateCountInput : IRequest<ApplicationServiceResponse<UpdateCountOutput>>
{
    [Required]
    [Range(1,int.MaxValue)]
    public int CountId { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string CountName { get; set; }
}
