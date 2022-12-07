internal class Program
{
    private static void Main(string[] args)
    {
        
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();

        var app = builder.Build();


        //Routing
        app.MapControllerRoute(
            name: "default",
            pattern: "/{controller=Product}/{action=Detail}/{id=1}/{name=ABC}"
            );

        app.Run();
    }
}