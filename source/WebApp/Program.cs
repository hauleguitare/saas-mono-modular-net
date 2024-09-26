using WebApp.Bootstrapper;

var builder = WebApplication.CreateBuilder(args);

// Configure services
ApiBoostrapHelper.ConfigureServices(builder.Services, builder.Configuration, builder.Environment);

var app = builder.Build();

// Register middlewares
ApiBoostrapHelper.RegisterMiddlewares(app);

// App run
app.Run();

