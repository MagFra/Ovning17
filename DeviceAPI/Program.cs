using DeviceAPI.Collections;
using DeviceAPI.Endpoints;
using Microsoft.Extensions.Options;


namespace DeviceAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddAuthentication().AddJwtBearer();
            builder.Services.AddAuthorization();
            var specOrigin = "MySpecOrigin";
            builder.Services.AddCors(options => 
            {
                options.AddPolicy(name: specOrigin, policy => 
                {
                    policy.WithOrigins("https://localhost:7210")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSingleton<IDeviceDataService, DeviceDataService>();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();

            app.RegisterUserEndpoint(new DeviceDataService());



            app.Run();
        }
    }
}
