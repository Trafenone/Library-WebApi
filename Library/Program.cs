using Library.Data;
using Library.Mapping;
using Library.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddAutoMapper(typeof(AppMappingProfile));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var scoped = app.Services.CreateScope();
SeedData.EnsurePopulated(scoped.ServiceProvider.GetRequiredService<ApplicationDbContext>());

app.Run();
