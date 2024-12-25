using salasyreservas.Helpers;
using salasyreservas.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<SalaServices>();

string? connectionString = builder.Configuration.GetConnectionString("BaseDeDatos");


if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("La cadena de conexión 'BaseDeDatos' no está configurada correctamente.");
}

builder.Services.AddSingleton(new DatabaseHelper(connectionString!));

builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
