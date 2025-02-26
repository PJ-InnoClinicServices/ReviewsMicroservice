using Infrastructure;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterRepositories();
builder.Services.RegisterServices();

builder.Services.AddSingleton<MongoDbService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();