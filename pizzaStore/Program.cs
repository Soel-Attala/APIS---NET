using Microsoft.OpenApi.Models;
using PizzaStore.DB;


var builder = WebApplication.CreateBuilder(args);
    
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaStore Minimal API", Description = "Making the Pizzas you love", Version = "v1" });
});
    
var app = builder.Build();
    
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI(c =>
   {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
   });
}

//GET
app.MapGet("/pizzas/{id}", (int id) => PizzaDB.GetPizza(id));
app.MapGet("/pizzas", () => PizzaDB.GetPizzas());

//POST
app.MapPost("/pizzas", (Pizza pizza) => PizzaDB.CreatePizza(pizza));

//PUT
app.MapPut("/pizzas", (Pizza pizza) => PizzaDB.UpdatePizza(pizza));

//DELETE
app.MapDelete("/pizzas/{id}", (int id) => PizzaDB.RemovePizza(id));



app.Run();
