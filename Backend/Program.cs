// necessary elements
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy => {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

//BudgetController.cs
builder.Services.AddControllers();
//"demo"
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BudgetContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
// build the app
var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// decrypted redirection
app.UseHttpsRedirection();

// authorization
app.MapControllers();

// run the app
app.Run();