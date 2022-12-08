var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapControllerRoute(
            name: "default",
            pattern: "/{controller=Order}/{action=Detail}/{id=10248}"
            );
app.MapControllerRoute(
            name: "default1",
            pattern: "/{controller=Order}/{action=Detail}/{id?}/{cid?}"
            );


app.Run();
