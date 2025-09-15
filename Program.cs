using CQRSExample;
using CQRSExample.CQRS.Commands;
using CQRSExample.CQRS.Queries;

Console.WriteLine("Hello, World!");

// Setup DbContext
using var context = new AppDbContext();
context.Database.EnsureCreated();

// CQRS Command: Add a product
var addHandler = new AddProductCommandHandler(context);
var productId = addHandler.Handle(new AddProductCommand { Name = "Sample Product", Price = 99.99M }).Result;
Console.WriteLine($"Added Product with Id: {productId}");

// CQRS Command: Update the product
var updateHandler = new UpdateProductCommandHandler(context);
var updateResult = updateHandler.Handle(new UpdateProductCommand { Id = productId, Name = "Updated Product", Price = 149.99M }).Result;
Console.WriteLine(updateResult ? $"Product {productId} updated." : $"Product {productId} not found for update.");

// CQRS Query: Get product by Id
var getByIdHandler = new GetProductByIdQueryHandler(context);
var productById = getByIdHandler.Handle(new GetProductByIdQuery { Id = productId }).Result;
if (productById != null)
    Console.WriteLine($"Product by Id: Id: {productById.Id}, Name: {productById.Name}, Price: {productById.Price}");
