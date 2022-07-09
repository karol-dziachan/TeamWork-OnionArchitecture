using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamWorkMVC.Application.InterfacesServices;
using TeamWorkMVC.Application.Mapping;
using TeamWorkMVC.Application.Services;
using TeamWorkMVC.Domain.InterfacesRepository;
using TeamWorkMVC.Domain.Models;
using TeamWorkMVC.Infrastructure;
using TeamWorkMVC.Infrastructure.Repositores;

/*
 * test@gmail.com
 * Karol123!
 */

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ContextConnection' not found.");

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("TeamWorkMVC.Web")));


//default
builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddUserManager<UserManagementService>()
    .AddEntityFrameworkStores<Context>();

builder.Services.AddScoped<UserManager<AppUser>>();

// Add services to the container.
/*var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("TeamWorkMVC.Web")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();*/

/*
builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddUserManager<UserManagementService>()
    .AddEntityFrameworkStores<Context>();
    */


/*
builder.Services.AddIdentity<IdentityUser<AppUser>, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<Context>()
    .AddUserManager<UserManagementService>() // Add ApplicationUserManager
    .AddDefaultTokenProviders()
    .AddDefaultUI();*/

/*builder.Services.AddIdentity<UserManagementService, IdentityRole>();*/

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<ITaskRepository, TaskRepository>();

builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
builder.Services.AddTransient<IProjectService, ProjectService>();

builder.Services.AddTransient<ICommentRepository, CommentRepository>();
builder.Services.AddTransient<ICommentService, CommentService>();

builder.Services.AddTransient<IUserManagementRepository, UserManagementRepository>();
builder.Services.AddTransient<IUserManagementService, UserManagementService>();

/*builder.Services.AddIdentity<IdentityUser, UserManagementService>().AddEntityFrameworkStores<Context>();*/

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

