using Business.Services.Repositories;
using Core.DataAccess.GenericRepositories;
using DataAccess.Contexts;
using Entities.Concrete;

namespace DataAccess.Repositories
{
    internal class CategoryRepository : EfEntityRepositoryBase<Category, AppDbContext, string>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}