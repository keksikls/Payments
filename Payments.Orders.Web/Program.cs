using Payments.Orders.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.AddBearerAuthentication();
builder.AddOptions();
builder.AddSwagger();
builder.AddData();
builder.AddApplicationServices();
builder.AddIntegrationServices();


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
