using Microsoft.AspNetCore.HttpLogging;
using Payments.Orders.Web.Extensions;
using Payments.Orders.Web.Filters;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(opt => opt.Filters.Add<ApiExceptionFilter>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpLogging(opt =>
{
    opt.LoggingFields = HttpLoggingFields.RequestBody | HttpLoggingFields.RequestHeaders | HttpLoggingFields.Duration |
     HttpLoggingFields.RequestPath | HttpLoggingFields.ResponseBody | HttpLoggingFields.ResponseHeaders;
});


builder.AddBearerAuthentication();
builder.AddOptions();
builder.AddSwagger();
builder.AddData();
builder.AddApplicationServices();
builder.AddIntegrationServices();
builder.AddBackgroundService();


var app = builder.Build();

app.UseHttpLogging();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
