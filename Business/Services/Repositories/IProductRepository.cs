using Core.DataAccess.GenericRepositories;
using Entities.Concrete;

namespace Business.Services.Repositories
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
    }
}