using KingStatterWenAPI.Interface;
using KingStatterWenAPI.Models;
using KingStatterWenAPI.WebAPILogic;

namespace KingStatterWenAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<KingStatterDataBaseSettings>(
                builder.Configuration.GetSection("KingStatterDataBase"));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IUserLogic,UserLogicDAO>();
            builder.Services.AddScoped<IMatchLogic, MatchDAO>();
            builder.Services.AddScoped<ICricInfo, CricInfoDAL>();

            builder.Services.AddHttpClient<CricInfoDAL>(client =>
            {
                client.BaseAddress = new Uri("https://cricbuzz-cricket.p.rapidapi.com/");
                // Additional HttpClient configurations, if any
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("client-allowed", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                    ;
                });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            
            app.UseCors("client-allowed");

            app.MapControllers();

            app.Run();
        }
    }
}