
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senac.eShop.Application.AutoMapper;
using Senac.eShop.Infra.Data.Context;
using Serilog;


namespace Senac.eShop.Infra.API.Configuration
{
    public static class ApiConfig
    {

        public static void ConfigureStartupConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddCors(c => c.AddPolicy("MyPolicy",
                policy => policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));

            services.AddControllers();
            services.RegisterServices();
            AddJwtConfiguration(services);

            services.AddSwaggerGen();
            services.AddHttpContextAccessor();
            //services.AddAutoMapper(AppDomain.CurrentDomain.Load("Senac.eShop.Application"));
            services.AddAutoMapper(typeof(AutoMapperConfig));
            services.DbContextConfigureServices(configuration);
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddAuthorization();
            services.AddIdentityApiEndpoints<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }

        private static void AddJwtConfiguration(IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SigningCredentialsConfiguration.Key,//new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Consts.SecretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        public static WebApplication UseStartupConfiguration(this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("MyPolicy");

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();

            app.MapIdentityApi<IdentityUser>();

            app.MapPost("/logout", async (SignInManager<IdentityUser> signInManager,
    [FromBody] object empty) =>
            {
                if (empty != null)
                {
                    await signInManager.SignOutAsync();
                    return Results.Ok();
                }
                return Results.Unauthorized();
            }).RequireAuthorization();

            return app;
        }

        public static void ConfigureSerilog(this ConfigureHostBuilder builder)
        {
            builder.UseSerilog((ctx, lc) => lc.WriteTo.Console());
        }
    }
}
