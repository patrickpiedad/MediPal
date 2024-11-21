using MediPal.Components;
using MediPal.Components.Account;
using MediPal.Components.Services;
using MediPal.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using Syncfusion.Licensing;


namespace MediPal
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            //Add SyncFusion Blazor components
            builder.Services.AddSyncfusionBlazor();

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            //Adding custom services and adaptors
            builder.Services.AddScoped<ISymptomService, SymptomService>();
            builder.Services.AddScoped<INoteService, NoteService>();
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            builder.Services.AddScoped<IPatientService, PatientService>();
            builder.Services.AddScoped<IDoctorService, DoctorService>();
            //builder.Services.AddScoped<AppointmentAdaptor>();

            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<IdentityUserAccessor>();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

            builder.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                })
                .AddIdentityCookies();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            //RequireConfirmedAccount changed to FALSE for a development environment, need to change after email service is implemented and in production environment
            builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders()

                //Adding UserManager service to enable creation of account upon app start if it does not exist
                .AddUserManager<UserManager<ApplicationUser>>();


            builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

            //Add SyncFusion Blazor Licensing

            //7 Day Trial
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF5cWWtCf1NpQnxbf1x0ZFRHal1ZTnZZUiweQnxTdEFjUHxecXVUTmBaUEF1Xw==");

            //30 Day Trial
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("@32372e302e30Ceo8C68485I/nSECWJP7MFuWdt4iLEajmhaZpojzI9o=");

            //Community License
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzUwNzA2NEAzMjM3MmUzMDJlMzBJRzZscUdmbnJITWRIY3ZHdXVsOG41ZE1sc1NQMzUyU3lKNmhyMk41d1dRPQ==");


            var app = builder.Build();


 

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // app.UseStaticFiles();
            app.MapStaticAssets();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            // Add additional endpoints required by the Identity /Account Razor components.
            app.MapAdditionalIdentityEndpoints();

            //Create the "Admin", "Patient", and "Doctor" roles if they do not exist when app starts and is connected to a database
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "Admin", "Patient", "Doctor" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            //Create an Admin account if it does not exist when app starts and is connected to a database
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string email = "admin@medipal.com";
                string password = "Admin#1";
                string firstname = "admin";
                string lastname = "admin";
                string gender = "male";
                DateOnly dateOfBirth = DateOnly.FromDateTime(DateTime.Now);
                //string MedicalDiagnosis = "none";


                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new ApplicationUser();
                    user.UserName = email;
                    user.Email = email;
                    user.FirstName = firstname;
                    user.LastName = lastname;
                    user.Gender = gender;
                    user.DateOfBirth = dateOfBirth;

                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user, "Admin");
                }

            }

            app.Run();
        }
    }
}
