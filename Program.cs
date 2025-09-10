//Written 9/5 by jvanloon
//By help of Claude AI with some tweaks thereafter
//Program.cs Creates an WebApplication Builder and adds services


//Local variable of the WebApplicationBuilder
//creates a minimal API
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); //configures MVC services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Allows for creation of Swagger documentation generation. 

// Register our custom service
// Makes it so the singleton pattern is employed and only one instance of the class can be created throughout the lifetime of the app.
builder.Services.AddSingleton<ArrestedAPI.Services.IQuotationService, ArrestedAPI.Services.QuotationService>();

//Builds the app
var app = builder.Build();

// Configure the HTTP request pipeline.
// Name is in IWebHostEnvironment
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