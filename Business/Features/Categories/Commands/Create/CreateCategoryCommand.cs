using Business.Services.Repositories;
using Entities.Concrete;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Business.Features.Categories.Commands.Create
{
    public record CreateCategoryCommand(
       string Name) : IRequest<CreateCategoryCommandResult>;
    public record CreateCategoryCommandResult(
        string Id,
        string Name);
    internal class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CreateCategoryCommandHandler> _logger;

        public CreateCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            ILogger<CreateCategoryCommandHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<CreateCategoryCommandResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(JsonSerializer.Serialize(request));
            Category category = new() { Name = request.Name };
            Category addedCategory = await _categoryRepository.AddAsync(category);
            return new CreateCategoryCommandResult(addedCategory.Id, addedCategory.Name);
        }
    }
}
