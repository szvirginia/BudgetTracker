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


builder.Services.AddDbContext<BudgetContext>(opt => opt.UseInMemoryDatabase("BudgetList"));
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