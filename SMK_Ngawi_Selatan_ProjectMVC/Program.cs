using Microsoft.EntityFrameworkCore;
using SmkNgawi.Data;
using SmkNgawi.Services;

var builder = WebApplication.CreateBuilder(args);

//daftarkan mvc 
builder.Services.AddControllersWithViews();

//add database 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("data Source=smkngawi_v2.db"));

//add services dengan dependency injection
//artinya kalau ada kontorler yang butush resgistrion service maka akan dibuat otomatis
builder.Services.AddScoped<RegistrationService>();

var app = builder.Build();

//bagaian bawah standard bawaan error throw
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();    
}


//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


//routing default control home action index
app.MapControllerRoute(
    name :"deafault",
    pattern: "{controller=Home}/{action=Index}/{id}"
);

app.Run();