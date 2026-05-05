using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. ПОДКЛЮЧЕНИЕ БАЗЫ ДАННЫХ
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString)); 

// 2. НАСТРОЙКА IDENTITY (Безопасность)
builder.Services.AddDefaultIdentity<IdentityUser>(options => {
    // Упрощаем требования к паролю для удобства тестов
    options.Password.RequireDigit = false; 
    options.Password.RequiredLength = 4;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    
    // Важно: отключаем обязательное подтверждение почты, 
    // чтобы сразу заходить после регистрации
    options.SignIn.RequireConfirmedAccount = false;
    
    // Блокировка при неверном вводе (по желанию)
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// 3. ПОДКЛЮЧЕНИЕ КОНТРОЛЛЕРОВ И РЕЙЗОР-СТРАНИЦ
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); 
builder.Services.AddOpenApi();

var app = builder.Build();

// 4. НАСТРОЙКА КОНВЕЙЕРА (Middleware)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseDeveloperExceptionPage(); // Показывает детальные ошибки при разработке
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// СТРОГО В ЭТОМ ПОРЯДКЕ:
app.UseAuthentication(); // Кто ты?
app.UseAuthorization();  // Что тебе можно?

// 5. МАРШРУТИЗАЦИЯ
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Avvik}/{action=Index}/{id?}");

// Это критически важно для работы страниц логина, регистрации и управления профилем
app.MapRazorPages(); 

app.Run();