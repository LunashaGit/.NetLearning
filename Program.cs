using Microsoft.Data.SqlClient; 
using Microsoft.EntityFrameworkCore;
using Todo.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

string connectionString = app.Configuration.GetConnectionString("DefaultConnection")!;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

try{
    using var conn = new SqlConnection(connectionString);
    conn.Open();
    Console.WriteLine("Connection Open ! ");
} catch (Exception ex){
    Console.WriteLine("Can not open connection ! ");
    Console.WriteLine(ex.Message);
}

app.UseAuthorization();

app.MapControllers();

app.Run();
