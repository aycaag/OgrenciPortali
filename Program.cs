using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// DB Bağlantısını sağlamak gerek 
builder.Services.AddDbContext<OgrenciPortaliDbContext>(
    options => options.UseSqlServer ("Server=localhost;Database=OgrenciPortal;User Id=sa;Password=reallyStrongPwd123 ;Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;")
);

builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IUserRepository,UserRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
