using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleShop.BLL.Counts.Commands;
using SimpleShop.BLL.Products.Commands;
using SimpleShop.DAL.Counts;
using SimpleShop.DAL.DbContexts;
using SimpleShop.DAL.Framework;
using SimpleShop.Model.Products.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ShopDbContext>(c=>c.UseSqlServer("Server=.; Initial Catalog=SimpleShop; Integrated Security = SSPI").
    AddInterceptors(new AddAuditFieldInterceptor()));

builder.Services.AddMediatR(
    typeof(CreateCountAppService).Assembly,
    typeof(CreateProductAppService).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICountRepository, EfCountRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
