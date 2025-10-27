using Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSignalR();
builder.Services.AddSingleton<TreeBuilder>();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://rtcclient-dmeea3dkbkfpekc0.centralindia-01.azurewebsites.net")
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