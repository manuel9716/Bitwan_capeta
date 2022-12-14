using CRUD.DbContexts;
using CRUD.Extentions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;



var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddUsuarioExtention();
builder.Services.AddDbContext<CrudDbContext>(x=>x.UseSqlServer("Data Source=BITWAN-MANUEL\\MANUELDB; Initial Catalog=NetCore6; Integrated Security=True; Connect Timeout=30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailOver=False"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseCors(options => options.AllowAnyOrigin());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}



app.MapControllers();

app.Run();

