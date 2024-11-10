using empAI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Set to listen on HTTP only at port 5048
builder.WebHost.UseUrls("http://localhost:5048");

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(); // Add Newtonsoft.Json support

// Configure Entity Framework with MySQL
builder.Services.AddDbContext<EmployeeContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21))));

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader();
    });
});

// Add Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger in development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "empAI API V1");
        c.RoutePrefix = string.Empty; // Swagger at root (http://localhost:5048)
    });
}

// Enable CORS with the "AllowAll" policy
app.UseCors("AllowAll");

// Enable static files serving (for the HTML, CSS, and JavaScript in wwwroot)
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
