using SkyrimQuestLog.Data;
using Microsoft.EntityFrameworkCore;
using SkyrimQuestLog.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SkyrimQuestLogConnection") ?? throw new InvalidOperationException("Connection string 'SkyrimQuestLogConnection' not found.");

builder.Services.AddDbContext<SkyrimQuestLogDb>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IQuestRepository, QuestRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
