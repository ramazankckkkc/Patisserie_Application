using Business.Services.Repositories;
using Entities.Concrete;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Business.Features.Products.Commands.Create
{
    public record CreateProductCommand(
        string Name,
        string BarcodeNumber,
        decimal Price,
        string CategoryId) : IRequest<CreateProductCommandResult>;
    public record CreateProductCommandResult(
        string Id,
        string Name,
        string BarcodeNumber,
        decimal Price,
        string CategoryId);

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<CreateProductCommandHandler> _logger;

        public CreateProductCommandHandler(IProductRepository productRepository, ILogger<CreateProductCommandHandler> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }
        public async Task<CreateProductCommandResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(JsonSerializer.Serialize(request));
            Product product = new()
            {
                Name = request.Name,
                BarcodeNumber = request.BarcodeNumber,
                Price = request.Price,
                CategoryId = request.CategoryId,
            };
            Product addedProduct = await _productRepository.AddAsync(product);
            return new CreateProductCommandResult
              (
                   addedProduct.Id,
                  addedProduct.Name,
                  addedProduct.BarcodeNumber,
                 addedProduct.Price,
                  addedProduct.CategoryId
              );
        }
    }
}