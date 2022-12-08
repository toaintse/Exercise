var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapControllerRoute(
            name: "default",
            pattern: "/{controller=Order}/{action=Detail}/{id=10248}"
            );


app.Run();
