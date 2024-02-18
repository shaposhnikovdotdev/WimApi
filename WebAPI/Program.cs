using WebAPI.Extensions;

var customSpecificOrigin = "customSpecificOrigin";
var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioningExtension();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "WimApi", Version = "v1" });
});

//Enable CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: customSpecificOrigin, builder =>
    {
        builder.WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader();
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

app.UseCors(customSpecificOrigin);

app.UseAuthorization();

app.UseErrorHandlingMiddleware();

app.MapControllers();

app.Run();
