var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5005", "https://localhost:5006");

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

var allowedOrigins = builder.Configuration
  .GetSection("Cors:AllowedOrigins")
  .Get<string[]>() ?? Array.Empty<string>();

builder.Services.AddCors(options => {
  options.AddPolicy("AllowClient", policy =>
      policy.WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("AllowClient");

if (!app.Environment.IsDevelopment()) {
  app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
