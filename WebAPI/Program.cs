using System.Reflection;
using FluentValidation;
using Web.BusinessLayer.Abstract;
using Web.BusinessLayer.Concrete;
using Web.BusinessLayer.Container;
using Web.BusinessLayer.ValidationRules.BookingValidations;
using Web.DataAccessLayer.Abstract;
using Web.DataAccessLayer.Concrete;
using Web.DataAccessLayer.EntityFramework;
using WebAPI.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .WithOrigins("https://localhost:7060"); // WebUI portunu yaz buraya
    });
});
builder.Services.AddSignalR();

builder.Services.AddDbContext<WebContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.ContainerDependencies();

builder.Services.AddValidatorsFromAssemblyContaining<CreateBookignValidation>();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

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
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<WebHub>("/WebHub");
app.Run();
