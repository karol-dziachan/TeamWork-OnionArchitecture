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
 *
 * Admin:
 * karol.dziachan@gmail.com
 * Karol123!
 * 9621299b-539f-405c-9acd-d97a1a02d411
 *
 * PM:
 * pm@test.pl
 * Karol123!
 */

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ContextConnection' not found.");

builder.Services.AddDbContext<Context>(options =>
    {
        options.UseSqlServer(connectionString, b => b.MigrationsAssembly("TeamWorkMVC.Web"));
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
   );

//default
builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddUserManager<UserManagementService>()
    .AddEntityFrameworkStores<Context>();

builder.Services.AddScoped<UserManager<AppUser>>();

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

