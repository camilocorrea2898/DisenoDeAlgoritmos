using ApiRest.Model;

namespace ApiRest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IServiceCollection services = builder.Services;
            IConfiguration configuration = builder.Configuration;


            //Cadena de conexión
            ConnectionDB.SetBenderConnectionString(configuration);

            //Cors
            services.AddCors(c => { c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()); });
            services.AddControllers();

            var app = builder.Build();

            app.UseCors(x => x
             .AllowAnyMethod()
             .AllowAnyHeader()
             .SetIsOriginAllowed(origin => true) // allow any origin
             .AllowCredentials()); // allow credentials

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}