using Backend.Application.Features.Products.Commands.Create;
using Backend.Application.Features.Products.Commands.Update;
using Backend.Application.Features.Products.Queries.GetById;
using Backend.Application.Interfaces;
using Backend.Application.Mappings;
using Backend.Infrastructure.Persistence;
using Backend.Infrastructure.Repositories;
using Backend.WebApi.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: myAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<CreateProductCommand>();

builder.Services.AddScoped<GetProductByIdQuery>();

builder.Services.AddScoped<UpdateProductCommand>();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
