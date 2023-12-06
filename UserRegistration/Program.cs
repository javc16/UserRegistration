using Microsoft.EntityFrameworkCore;
using UserRegistration.DBContext;
using UserRegistration.DBContext.Repository;
using UserRegistration.Domain;
using UserRegistration.Models;
using UserRegistration.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserRegistrationContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("MyContextConnection")));

//Repository
builder.Services.AddTransient<IRepository<Employee>, Repository<Employee>>();

//Register Services
builder.Services.AddScoped<EmployeeService>();

//Register Domain
builder.Services.AddScoped<EmployeeDomain>();

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
app.UseCors(builder => builder
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin()
    );
app.Run();


