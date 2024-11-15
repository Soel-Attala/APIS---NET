using Microsoft.OpenApi.Models;

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
app.MapGet("/", () => "Hello World!");
app.MapGet("/products", () => data);
app.MapGet("/products/{id}", (int id) => data.SingleOrDefault(product => product.Id == id));

//POST
app.MapPost("/products", (Product product) => /**/);

//PUT 
app.MapPut("/products", (Product product) => /* Update the data store using the `product` instance */);

//DELETE 
app.MapDelete("/products/{id}", (int id) => /* Remove the record whose unique identifier matches `id` */);


app.Run();
