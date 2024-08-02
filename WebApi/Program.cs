using WebApi.ExtensionMigration;
using Persistence.DependencyInjection;
using WebApi.EndPoints;
using Application.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.PersistenceServices(builder.Configuration);
builder.Services.AddServiceApplication();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ApplyMigration();
app.UseHttpsRedirection();
app.CategoriaAlimentosEndPoints();
app.AlimentosEndPoints();
app.Run();


