using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FiltroApi.Data;
using FiltroApi.Services;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

//SWAGGER configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CORS configuration
builder.Services.AddCors(options =>{
    options.AddPolicy("AllowAnyOrigin", builder =>{
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

//INJECT DEPENDENCIES configuration
builder.Services.AddScoped<IOwnersServices, OwnersServices>();
builder.Services.AddScoped<IVetsServices, VetsServices>();
builder.Services.AddScoped<IPetsServices, PetsServices>();
builder.Services.AddScoped<IQuotesServices, QuotesServices>();

//VALIDATOR configuration
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<OwnerValidator>();

// JSON IGNORE.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

//DATABASE configuration
builder.Services.AddDbContext<ApiContext>(options =>{
    options.UseMySql(
        builder.Configuration.GetConnectionString("FiltroApi"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")
    );
});

//Dependencia del MailerSend
builder.Services.AddScoped<EmailsServices>();

//API ROUTE configuration
builder.Services.AddControllers(); //IMPORTANTE PONER SIEMPRE

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
//APP configuration
app.UseCors("AllowAnyOrigin");
app.MapControllers(); //IMPORTANTE PONER SIEMPRE

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
