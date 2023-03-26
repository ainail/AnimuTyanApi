using AnimuTyanApi.Middleware;

namespace AnimuTyanApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.RegisterServices();

            var app = builder.Build();


            app.UseCors(b => b
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials()
                .WithExposedHeaders("set-cookie", "Content - Type", "Depth", "User - Agent", "X - File - Size", "X - Requested - With",
                    "If - Modified - Since"," X - File - Name", "Cache - Control", ".AspNetCore.Cookies", "X-Requested-With", "X-HTTP-Method-Override"));

            app.UseAuthentication();
            app.UseAuthorization();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.AddErrorHandlingMiddleware();

            app.MapControllers();

            app.Run();
        }
    }
}