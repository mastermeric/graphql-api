using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Kovan.API.Models;
using Kovan.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//REACT UI 3000  den haberlesecek.
builder.Services.AddCors(opt =>
            opt.AddPolicy(name: "ApiCorsPolicy", builder =>
            builder.WithOrigins("http://localhost:56604", "http://localhost:3000", "http://localhost:56604")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()));


//Servis ilaveleri   (inject ediyoruz)
builder.Services.AddScoped<IItemsService, ItemsService>();

// GraphQLServer ekliyoruz  (inject ediyoruz)
builder.Services.AddGraphQLServer().AddQueryType<Query>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UsePlayground( new PlaygroundOptions
    { 
        QueryPath = "/graphql",
        Path = "/playground"
    });
}

app.UseCors("ApiCorsPolicy"); //call UseCors before the UseAuthorization, UseEndpoints


app.UseAuthorization();

app.MapControllers();

app.MapGraphQL("/graphql"); //"graphql" olabilir..

app.Run();
