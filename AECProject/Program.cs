namespace AECProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. Day 8
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(
                options =>
                {
                    options.IdleTimeout = TimeSpan.FromMinutes(30);//change sesion time out
                }
                );//add setting

            var app = builder.Build();

            // Configure the HTTP request pipeline. middlewre day3
            #region Custom Middlewrae (PipLine)

            //app.Use(async (httpContext, next) => {

            //   await httpContext.Response.WriteAsync("1- Middleware 1\n");//block
            //   await  next.Invoke();
            //   await httpContext.Response.WriteAsync("1-1 Middleware 1-1\n");//block

            //});
            //app.Use(async (httpContext, next) => {
            //    await httpContext.Response.WriteAsync("2- Middleware 2\n");//block
            //    await next.Invoke();
            //    await httpContext.Response.WriteAsync("2-2 Middleware 2-2\n");//block


            //});
            //app.Run(async (httpContext) =>//terminate
            //{
            //    await httpContext.Response.WriteAsync("3- Terminate\n");
            //});//excute midleware


            #endregion


            #region Built In pipline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();// client side files js

            app.UseSession();//default settion
            
            //Guid request math any route define inside MapRoute
            app.UseRouting();//reuest controller ,action (r1)

            app.UseAuthorization();//not work


            //NAmeing convention route
            //app.MapControllerRoute("Route1",
            //                       "s/{name}/{age:int:range(20,60)}/{color?}",
            //                       new {controller="Route",action= "Method1" });
          
            //app.MapControllerRoute("r1", "{controller=Route}/{action=Method1}");
          

            //app.MapControllerRoute("r2", "s2",
            //    new { Controller = "Route", action = "MEthod2" });



            //DEfine Route (Plan) & execute (Run)
            app.MapControllerRoute( //url ==>execute
                name: "default",
                pattern: "{controller=Employee}/{action=Index}/{id?}");
            #endregion

            app.Run();//astrat
        }
    }
}
