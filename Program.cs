using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using MiddlewareTest.Infra.Cors;
using MiddlewareTest.Infra.Filter;
using MiddlewareTest.Infra.Middleware;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IMessageWriter, LoggingMessageWriter>();
builder.Services.AddControllers(options =>
{
    options.AddFilter();
});
builder.Services.AddCorsSetting(builder.Environment);
//builder.Services.AddMvc(config => config.Filters.Add(typeof(ExceptionFilter)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors();


app.UseAuthorization();

//app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

//app.UseMiddlewareTest();

//app.UseMiddlewareTest2();

app.MapControllers();

app.Run();
