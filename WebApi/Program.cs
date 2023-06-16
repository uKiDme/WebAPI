using WebApi;

var builder = WebApplication.CreateBuilder(args);

// Create a new instance of the Startup class, passing the application's configuration to its constructor
var startup = new Startup(builder.Configuration);

// Call the ConfigureServices method of the Startup class to configure services for dependency injection
startup.ConfigureServices(builder.Services);

// Add MVC controllers as services to the application's service container
builder.Services.AddControllers();

// Add API explorer services to the application's service container
builder.Services.AddEndpointsApiExplorer();

// Add Swagger services to the application's service container
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Check if the application is running in the development environment
if (app.Environment.IsDevelopment())
{
    // Enable Swagger middleware to provide API documentation
    app.UseSwagger();

    // Enable Swagger UI middleware for interactive API testing
    app.UseSwaggerUI();
}

// Add middleware to redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Add middleware to enable authorization for protected endpoints
app.UseAuthorization();

// Map controllers and their actions as endpoints
app.MapControllers();

// Start the application and listen for incoming HTTP requests
app.Run();