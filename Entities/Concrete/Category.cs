namespace Entities.Concrete
{
    public class Category : BaseEntity<string>
    {
        public Category()
        {
            Id = Ulid.NewUlid().ToString();
        }
        /// <summary>
        /// Kategori ismi...
        /// </summary>
        public string Name { get; set; } = default!;
    }
}