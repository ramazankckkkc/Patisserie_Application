namespace Core.Bases
{
    public abstract class BaseEntity<TId> 
    {
        public BaseEntity()
        {
        }
        public BaseEntity(TId id) : this()
        {
            Id = id;
        }
        public TId Id { get; set; } = default!;
        public bool IsDeleted { get; set; } = false;
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

    }
}
