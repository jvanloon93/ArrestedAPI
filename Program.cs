var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register our custom services
builder.Services.AddSingleton<ArrestedAPI.Services.IProductService, ArrestedAPI.Services.ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable static files (for serving HTML, CSS, JS, etc.)
app.UseStaticFiles();

// Configure default file handling (serves index.html by default)
app.UseDefaultFiles();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

// Fallback to serve index.html for client-side routing
app.MapFallbackToFile("index.html");

app.Run();