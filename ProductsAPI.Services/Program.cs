using ProductsAPI.Infra.IoC.Extensions;
using ProductsAPI.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerDoc();
builder.Services.AddSqlServerConfig(builder.Configuration);
builder.Services.AddMongoDBConfig(builder.Configuration);
builder.Services.AddDependencyInjection();
builder.Services.AddMediatRConfig();
builder.Services.AddJwtBearer(builder.Configuration);
builder.Services.AddCorsPolicy();

var app = builder.Build();

app.UseSwaggerDoc();
app.UseCorsPolicy();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

public partial class Program { }