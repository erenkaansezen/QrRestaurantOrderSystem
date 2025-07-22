using Web.BusinessLayer.Abstract;
using Web.BusinessLayer.Concrete;
using Web.DataAccessLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebContext>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
