namespace Entities.Concrete
{
    public class User : BaseEntity<string>
    {
        public User()
        {
            Id = Ulid.NewUlid().ToString();
        }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? TcNo { get; set; }
        public string? BirthDay { get; set; }
        public char Gender { get; set; }
        public string PhoneNumber { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Title { get; set; } = default!;
    }
}