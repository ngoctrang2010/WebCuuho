using Microsoft.EntityFrameworkCore;
using WebRong.Models;
using WebRong.Repository;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<CuuhoWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();//chỉnh thằng này
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddRazorPages();
builder.Services.AddScoped<IBaivietRepository, EFBaivietRepository>();
builder.Services.AddScoped<IDichvuRepository, EFDichvuRepository>();
builder.Services.AddScoped<ILienheRepository, EFLienheRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute( // thêm thằng này nữa
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
