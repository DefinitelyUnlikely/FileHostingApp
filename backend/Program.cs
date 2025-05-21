using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Interfaces;
using Backend.Services;
using Backend.Data.Repositories;

namespace Backend;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                            policy =>
                            {
                                policy.WithOrigins("http://localhost:5173")
                                        .AllowCredentials()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                            });
        });

        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(DatabaseConfig.connectionString));

        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme)
            .AddBearerToken(IdentityConstants.BearerScheme);

        builder.Services.AddIdentityCore<IdentityUser>(options => { options.User.RequireUniqueEmail = true; })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();

        builder.Services.AddLogging(logging =>
        {
            logging.AddConsole();
        });

        builder.Services.AddScoped<IFolderRepository, FolderRepository>();
        builder.Services.AddScoped<IFileRepository, FileRepository>();

        builder.Services.AddScoped<IFolderService, FolderService>();
        builder.Services.AddScoped<IFileService, FileService>();

        builder.Services.AddScoped<IAuthService, UserAuthService>();

        builder.Services.AddControllers();

        // build app
        var app = builder.Build();

        app.UseCors("AllowSpecificOrigin");
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapIdentityApi<IdentityUser>();
        app.MapControllers().RequireCors("AllowSpecificOrigin");

        app.Run();

    }
}
