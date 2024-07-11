using Business.Services.Repositories;
using Core.DataAccess.GenericRepositories;
using DataAccess.Contexts;
using Entities.Concrete;

namespace DataAccess.Repositories
{
    internal class ProductRepository : EfEntityRepositoryBase<Product, AppDbContext, string>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
