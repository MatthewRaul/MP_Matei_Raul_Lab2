using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Matei_Raul_Lab2.Data; // namespace-ul unde e Nume_Pren_Lab2Context
 // dacă LibraryIdentityContext e aici

var builder = WebApplication.CreateBuilder(args);

// DbContext aplicație (cărți, autori, borrowing)
builder.Services.AddDbContext<Matei_Raul_Lab2Context>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Matei_Raul_Lab2Context")
        ?? throw new InvalidOperationException("Missing 'Matei_Raul_Lab2Context' connection string.")));

// DbContext pentru Identity (utilizatori, roluri)
builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Matei_Raul_Lab2Context")
        ?? throw new InvalidOperationException("Missing 'Matei_Raul_Lab2Context' connection string.")));

// Identity pe contextul de Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    // poți relaxa regulile la nevoie:
    // options.Password.RequireNonAlphanumeric = false;
    // options.Password.RequiredLength = 6;
})
    .AddEntityFrameworkStores<LibraryIdentityContext>();

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
