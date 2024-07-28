using WebApi.ExtensionMigration;
using Persistence.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.PersistenceServices(builder.Configuration);
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ApplyMigration();
app.UseHttpsRedirection();
app.Run();


