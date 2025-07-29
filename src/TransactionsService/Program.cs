var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();

app.Run(); // DO NOT use .UseUrls() unless needed
