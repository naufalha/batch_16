using Microsoft.EntityFrameworkCore;
using SmkNgawi.Data;
using SmkNgawi.Services;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// 1. REGISTER SERVICES (Wadah Alat-Alat)
// ==========================================

// A. Daftarkan fitur MVC (Controller & View)
builder.Services.AddControllersWithViews();

// B. Daftarkan Database (SQLite)
// File database 'smkngawi_web.db' akan otomatis dibuat di folder project
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlite("Data Source=smkngawi_v2.db"));


// C. Daftarkan Service Logika (Dependency Injection)
// Agar Controller bisa minta tolong ke RegistrationService
builder.Services.AddScoped<RegistrationService>();


// ==========================================
// 2. BUILD APP
// ==========================================
var app = builder.Build();

// ==========================================
// 3. CONFIGURE PIPELINE (Aturan Jalan)
// ==========================================

// Jika bukan mode developer, pakai penanganan error standar
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Agar bisa baca file CSS/JS di folder wwwroot

app.UseRouting();

app.UseAuthorization();

// Aturan Rute Default
// Jika user buka alamat kosong "/", arahkan ke Home -> Index
// Jika user buka "/Student", arahkan ke Student -> Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();