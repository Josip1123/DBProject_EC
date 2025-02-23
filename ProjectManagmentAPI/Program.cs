
using Business.Services;
using Data.Contexts;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<ProjectsRepository>();
builder.Services.AddScoped<ProjectServices>();
builder.Services.AddScoped<CustomersRepository>();
builder.Services.AddScoped<CustomerServices>();
builder.Services.AddScoped<ProjectOwnerRepository>();
builder.Services.AddScoped<ProjectOwnerServices>();
builder.Services.AddScoped<ServicesRepository>();
builder.Services.AddScoped<ServiceServices>();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(b =>
    {
        b.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/err");
}

app.UseCors();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
