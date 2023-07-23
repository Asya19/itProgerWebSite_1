var builder = WebApplication.CreateBuilder(args);

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

// автоматические переадресации
app.UseHttpsRedirection();

// подключение статических файлов из папки wwwroot
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Отслеживание URL адресов
app.MapControllerRoute(
    name: "default",

    // Выбор главное контроллера (страницы) и вызов метода из него,
    // который показывает какой- прописанный шаблон
    // Открывается при переходе на главную страницу без передачи каких-либюо параметов
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
