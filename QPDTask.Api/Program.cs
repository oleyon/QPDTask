var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;



services.AddControllers();

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
