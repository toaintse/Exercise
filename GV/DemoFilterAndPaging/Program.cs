var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSession(); //
var app = builder.Build();
app.UseSession(); //
app.MapControllerRoute(
    name:"default",
    pattern:"/{controller=Order}/{action=List}"
    );

app.MapControllerRoute(
    name: "3parts",
    pattern: "/{controller=Order}/{action=List}/{id=0}"
    );

app.Run();
