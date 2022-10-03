using MediatR;
using SimpleShop.Model.Counts.Entities;
using SimpleShop.Model.Framework;
using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Model.Counts.Commands;

public class UpdateCount : IRequest<ApplicationServiceResponse<Count>>
{
    [Required]
    [Range(1,int.MaxValue)]
    public int Id { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string CountName { get; set; }
}
