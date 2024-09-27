using WebApp.Bootstrapper;

var builder = WebApplication.CreateBuilder(args);

// Configure services
ApiBootstrapHelper.ConfigureServices(builder.Services, builder.Configuration, builder.Environment);

var app = builder.Build();

// Register middlewares
ApiBootstrapHelper.RegisterMiddlewares(app);

// App run
app.Run();

