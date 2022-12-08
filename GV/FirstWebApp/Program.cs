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
            pattern: "/{controller=Product}/{action=Detail}/{id=0}"
            );
        app.MapControllerRoute(
           name: "default1",
           pattern: "/{controller=Product}/{action=Detail}/{id=0}/{cid}"
           );

        app.Run();
    }
}