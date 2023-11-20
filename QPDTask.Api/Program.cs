using QPDTask.Api;
using QPDTask.Service;
using QPDTask.Service.Configuration;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

var configuration = builder.Configuration;

services.AddAppService(configuration);

services.AddControllers();

services.AddAutoMappers();

var app = builder.Build();

var env = app.Environment;

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseRouting();

app.MapControllers();

app.Run();
