using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vicol_Lorena_Proiect.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{   options.AddPolicy("AdminPolicy", policy =>
    policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddRazorPages(options =>
{ options.Conventions.AuthorizeFolder("/Produse");
  options.Conventions.AllowAnonymousToPage("/Produse/Index");
  options.Conventions.AllowAnonymousToPage("/Produse/Details");
  options.Conventions.AuthorizeFolder("/Clienti", "AdminPolicy");
  options.Conventions.AuthorizeFolder("/Echipe", "AdminPolicy");
  options.Conventions.AuthorizeFolder("/Angajati", "AdminPolicy");
});

builder.Services.AddDbContext<Vicol_Lorena_ProiectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Vicol_Lorena_ProiectContext") ?? throw new InvalidOperationException("Connection string 'Vicol_Lorena_ProiectContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Vicol_Lorena_ProiectContext") ?? throw new InvalidOperationException("Connection string 'Vicol_Lorena_ProiectContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
