
using Application.Features.MediatR.Users.Handlers.Write;
using Application.Interfaces;
using Application.Interfaces.AnswerInterface;
using Application.Interfaces.AnswerLikeInterface;
using Application.Interfaces.DepartmentInterface;
using Application.Interfaces.QuestionInterface;
using Application.Interfaces.QuestionLikeInterface;
using Application.Interfaces.TokenInterface;
using Application.Interfaces.UniversitiesInterface;
using Application.Interfaces.UserInterface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence.Context;
using Persistence.Repositories;
using Persistence.Repositories.AnswerLikeRepository;
using Persistence.Repositories.AnswerRepository;
using Persistence.Repositories.DepartmentRepository;
using Persistence.Repositories.QuestionLikeRepository;
using Persistence.Repositories.QuestionRepository;
using Persistence.Repositories.TokenRepository;
using Persistence.Repositories.UniversitiesRepository;
using Persistence.Repositories.UserRepository;
using System.Text;
using Persistence;
using Application.Interfaces.StatisticInterface;
using Persistence.Repositories.StatisticRepository;
using Application.Interfaces.ReportInterface;
using Persistence.Repositories.ReportRepository;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {   
                        policy.WithOrigins(
                                "https://localhost:7230",
                                "http://localhost:5251"
                               )
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });


            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            builder.Services.AddAuthorization();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // DbContext'i ekle
            builder.Services.AddDbContext<UniHelperContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

            builder.Services.AddMediatR(cfg =>
             cfg.RegisterServicesFromAssembly(typeof(LoginCommandHandler).Assembly)
           );

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Application.MapperProfiles.MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            builder.Services.AddScoped<UniHelperContext>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
            builder.Services.AddScoped<ITokenRepository, TokenRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
            builder.Services.AddScoped<IQuestionLikeRepository, QuestionLikeRepository>();
            builder.Services.AddScoped<IAnswerLikeRepository, AnswerLikeRepository>();
            builder.Services.AddScoped<IUniversitiesRepository, UniversitiesRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
            builder.Services.AddScoped<IStatisticRepository, StatisticRepository>();
            builder.Services.AddScoped<IReportRepository, ReportRepository>();


            builder.Services.AddInfrastructureServices();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(MyAllowSpecificOrigins); // bunu UseRouting ile UseAuthorization arasýna koyabilirsin


            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
