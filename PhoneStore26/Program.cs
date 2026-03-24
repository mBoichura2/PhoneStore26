using BusinessLogic.Services;
using DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<PhoneStoreDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<PhoneStoreDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(PhoneService));

var app = builder.Build();




using (var scope = app.Services.CreateAsyncScope())
{
    var provider = scope.ServiceProvider;

    var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
    IdentityRole role1 = new IdentityRole("Admin");
    await roleManager.CreateAsync(role1);
    IdentityRole role2 = new IdentityRole("Customer");//Клієнт
    await roleManager.CreateAsync(role2);

    var userManager = provider.GetRequiredService<UserManager<IdentityUser>>();
    var user1 = await userManager.FindByNameAsync("a@b.c");
    await userManager.AddToRoleAsync(user1, "Admin");//role1.Name
    var user2 = await userManager.FindByNameAsync("mish@mish.mish");
    await userManager.AddToRoleAsync(user2, "Customer");//role2.Name
}




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
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
