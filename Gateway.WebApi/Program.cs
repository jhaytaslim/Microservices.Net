using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Polly;
using MMLib.SwaggerForOcelot.DependencyInjection;
using Gateway.Configurations;

var builder = WebApplication.CreateBuilder(args);

var routes = "Routes";

builder.Configuration.AddOcelotWithSwaggerSupport(options =>
{
    // options.Folder = routes;
    // options.FileOfSwaggerEndPoints = "ocelot.global";
});

builder.Services.AddOcelot(builder.Configuration).AddPolly();
builder.Services.AddSwaggerForOcelot(builder.Configuration);

// var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
// builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
//     .AddOcelot(routes, builder.Environment)
//     .AddEnvironmentVariables();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Swagger for ocelot
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwaggerForOcelotUI(builder.Configuration);
await app.UseOcelot();

// await app.UseSwaggerForOcelotUI(options =>
// {
//     options.PathToSwaggerGenerator = "/swagger/docs";
//     // options.ReConfigureUpstreamSwaggerJson = AlterUpstream.AlterUpstreamSwaggerJson;
// }).UseOcelot();

app.MapControllers();

app.Run();
