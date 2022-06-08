using DepartmentManager.Api.Middlewares;
using DepartmentManager.Data;
using DepartmentManager.Domain.Configs;
using DepartmentManager.Domain.Interfaces;
using DepartmentManager.Domain.Mapping;
using DepartmentManager.Domain.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));
var jwtConfig = builder.Configuration.GetSection("JwtConfig");
builder.Services.Configure<JwtConfig>(jwtConfig);
builder.Services.AddDbContext<DataContext>(a =>
    a.UseNpgsql(builder.Configuration.GetSection("ConnectionString").Value,
        b => b.MigrationsAssembly("DepartmentManager.Api")
    )
);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRuleService, RuleService>();
builder.Services.AddScoped<IApartmentService, ApartmentService>();
builder.Services.AddScoped<IReportService, ReportService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCorsPolicy", policy =>
    {
        policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    });
});


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
app.UseCors("DefaultCorsPolicy");
app.UseMiddleware<ErrorMiddleware>();
app.Run();