using WebLabApp.Controllers;
using WebLabApp.Models;
using Microsoft.EntityFrameworkCore;
using WebLabApp.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IWForecastRepository, WForecastRepository>();
builder.Services.AddControllers();
builder.Services.AddHostedService<BackgroundWorkerService>();

// получаем строку подключени€ из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавл€ем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllersWithViews(); //сервисы фреймворка MVC, которые позвол€ют использовать контроллеры и представлени€ и св€занную функциональность. 

var app = builder.Build();
app.UseHttpsRedirection(); // переадресаци€
app.UseStaticFiles(); // подключение статических файлов wwwroot
app.UseRouting(); // включение маршрутизации запросов
app.UseAuthorization(); // включение авторизации

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MainPage}/{action=Index}/{id?}");

app.Run();
