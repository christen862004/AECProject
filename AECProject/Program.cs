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

            app.UseRouting();//reuest controller ,action

            app.UseAuthorization();//not work

            app.MapControllerRoute( //url ==>execute
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion

            app.Run();//astrat
        }
    }
}
