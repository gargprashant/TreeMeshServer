using Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSignalR();
builder.Services.AddSingleton<TreeBuilder>();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://red-hill-072519500.3.azurestaticapps.net")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// ✅ Correct middleware order
app.UseRouting();       // 🔹 Enables endpoint routing
app.UseCors();          // 🔹 Applies CORS after routing

app.MapHub<TreeHub>("/TreeHub");

app.Run();