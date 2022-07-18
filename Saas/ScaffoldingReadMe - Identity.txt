Support for ASP.NET Core Identity was added to your project.

For setup and configuration information, see https://go.microsoft.com/fwlink/?linkid=2116645.


If you are using a user defined Identity (such as ApplicationUser), make sure you change:


in _LoginPartial.cshtml
================
	@inject SignInManager<IdentityUser> SignInManager
	@inject UserManager<IdentityUser> UserManager
to
	@inject SignInManager<ApplicationUser> SignInManager
	@inject UserManager<ApplicationUser> UserManager

in Program.cs
=============
    services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
to
    services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)

and add .AddDefaultTokenProviders(); eg
    services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

and add services.AddRazorPages(); // otherwise endpoint routing won't work


in ApplicationDbContext.cs
==========================
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
to
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>

in _manageNav.cshtml
====================
replace
    @inject SignInManager<IdentityUser> SignInManager
with
    @using Application.Models
    @inject SignInManager<ApplicationUser> SignInManager
