using Microsoft.EntityFrameworkCore;
using HR.Management.Infrastructure;
using HR.Management.Application.Features.Employees.Requests.Queries;
using MediatR;
using Microsoft.OpenApi.Models;
using HR.Management.Application.Interfaces;
using HR.Management.Infrastructure.Repositories;
using HR.Management.Application.Handlers;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Persistence.Repositories;
using HR.Management.Application.Features.AttendanceRecords.Requests.Commands;

var builder = WebApplication.CreateBuilder(args);

// Configure Entity Framework Core with Npgsql
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnectionForHR")));

// Other service configurations
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile)); // Register the AutoMapper profile
builder.Services.AddMediatR(typeof(GetEmployeeByIdQuery).Assembly);
builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.AddTransient<ILeaveRequestRepository, LeaveRequestRepository>();
// builder.Services.AddMediatR(typeof(GetLeaveRequestByIdQuery).Assembly);
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IPayrollRepository, PayrollRepository>();
builder.Services.AddScoped<ILeaveTypeRepository,LeaveTypeRepository>();
builder.Services.AddMediatR(typeof(GetDepartmentByIdHandler).Assembly);
builder.Services.AddTransient<IAttendanceRecordRepository, AttendanceRecordRepository>();
builder.Services.AddMediatR(typeof(CreateAttendanceRecordCommand).Assembly);


// Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "HR Management API",
        Version = "v1",
        Description = "API documentation for the HR Management System."
    });
    // Optionally, include XML comments if you have them for additional documentation
    // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    // c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "HR Management API V1");
        c.RoutePrefix = string.Empty; // Serve Swagger UI at the app root
    });
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
