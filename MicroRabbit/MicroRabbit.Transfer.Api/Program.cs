using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Infra.IoC;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Banking.Domain.Events;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.EventHandlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TransferDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TransferDbConnection"));
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Transfer Micro Service", Version = "v1" });
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

DependencyContainer.RegisterServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    //c.SwaggerEndpoint("v1/swagger.json", "Transfer Microservice V1");
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transfer Microservice V1");  //öneri üzerine deðiþtirildi gerekirse deðiþtirirsin eskisi üst satýrda
});
//49 - 55 arasýný silebilirsin çok saçma biþey ekletti adam
ConfigureEventBus(app);

void ConfigureEventBus(IApplicationBuilder app)
{
    var EventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
    EventBus.Subscribe<MicroRabbit.Transfer.Domain.Events.TransferCreatedEvent, TransferEventHandler>();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
