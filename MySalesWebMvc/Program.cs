using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySalesWebMvc.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuração do contexto do banco de dados
builder.Services.AddDbContext<MySalesWebMvcContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("MySalesWebMvcContext"),
        npgsqlOptions => npgsqlOptions.MigrationsAssembly("MySalesWebMvc")
    )
);

// Registro do serviço de seeding
builder.Services.AddScoped<SeedingService>();

// Adição de serviços ao contêiner
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Recupera o serviço de seeding
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var seedingService = services.GetRequiredService<SeedingService>();

    // Configuração do pipeline de requisição HTTP
    if (app.Environment.IsDevelopment())
    {
        Console.WriteLine("Ambiente de desenvolvimento detectado.");
        app.UseDeveloperExceptionPage();
        Console.WriteLine("Chamando SeedingService.Seed()...");
        seedingService.Seed(); // Popula o banco de dados com dados de exemplo
        Console.WriteLine("Seeding concluído.");
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
