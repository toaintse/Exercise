var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "/{controller=Employee}/{action=List}"
    );

app.MapControllerRoute(
    name: "3parts",
    pattern: "/{controller=Employee}/{action=List}/{id=0}"
    );

app.Run();
