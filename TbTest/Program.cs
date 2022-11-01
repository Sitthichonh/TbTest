using TbTest.Interfaces;
using TbTest.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<IUser, UserRepository>();
builder.Services.AddHttpClient<IThaipost, ThaipostRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
