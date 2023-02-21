using Library.Data;
using Library.Mapping;
using Library.Models.Repository;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddAutoMapper(typeof(AppMappingProfile)); 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(logging =>
    logging.LoggingFields = HttpLoggingFields.RequestMethod | HttpLoggingFields.RequestPath | 
    HttpLoggingFields.RequestQuery | HttpLoggingFields.ResponseStatusCode | 
    HttpLoggingFields.RequestBody
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHttpLogging();

var scoped = app.Services.CreateScope();
SeedData.EnsurePopulated(scoped.ServiceProvider.GetRequiredService<ApplicationDbContext>());

app.Run();
