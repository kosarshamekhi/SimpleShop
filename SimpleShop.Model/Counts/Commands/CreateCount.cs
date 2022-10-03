using MediatR;
using SimpleShop.Model.Counts.Entities;
using SimpleShop.Model.Framework;
using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Model.Counts.Commands;

public class CreateCount:IRequest<ApplicationServiceResponse<Count>>
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string CountName { get; set; }
}
