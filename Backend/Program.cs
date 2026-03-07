// necessary elements
var builder = WebApplication.CreateBuilder(args);

//BudgetController.cs
builder.Services.AddControllers();
//"demo"
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// build the app
var app = builder.Build();

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