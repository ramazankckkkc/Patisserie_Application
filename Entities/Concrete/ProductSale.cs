namespace Entities.Concrete
{
    public class ProductSale : BaseEntity<string>
    {
        public ProductSale()
        {
            Id = Ulid.NewUlid().ToString();
        }
        public string SaleId { get; set; } = default!;
        public Sale? Sale { get; set; }
        public string ProductId { get; set; } = default!;
        public Product? Product { get; set; }
    }
}