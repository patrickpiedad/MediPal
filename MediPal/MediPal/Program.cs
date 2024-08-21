using MediPal.Client.Pages;
using MediPal.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediPal.Data;
using MudBlazor.Services;

namespace MediPal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContextFactory<MediPalContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("MediPalContext") ?? throw new InvalidOperationException("Connection string 'MediPalContext' not found.")));

            builder.Services.AddQuickGridEntityFrameworkAdapter();

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            builder.Services.AddMudServices(); // Add MudBlazor services

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
    app.UseMigrationsEndPoint();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.Run();
        }
    }
}
