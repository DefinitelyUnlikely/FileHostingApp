using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace backend;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.Run();

    }
}
