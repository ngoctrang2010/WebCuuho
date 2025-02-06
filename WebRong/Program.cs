using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();//chỉnh thằng này
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllersWithViews();//thằng này nữa
var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute( // thêm thằng này nữa
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
