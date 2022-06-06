using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.Core.Web;
using Store.Data.AutoMapper;
using Store.Model.Store;
using Store.Data;
using Store.Data.Implementation;
using MediatR;
using System.Reflection;
using Store.Infrastructure;
using Store.Infrastructure.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StoredContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringDB")));

var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutoMapperEntitys()); });
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var assembly = AppDomain.CurrentDomain.Load("Store.Domain");
builder.Services.AddMediatR(assembly);

builder.Services.AddTransient<ResponseMiddleware>();

builder.Services.AddTransient<IArticleData, ArticleData>();
builder.Services.AddTransient<IStoreData, StoreData>();

builder.Services.AddTransient<IArticleLogic, ArticleLogic>();
builder.Services.AddTransient<IStoreLogic, StoreLogic>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("cors",
    builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("cors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ResponseMiddleware>();

app.Run();
