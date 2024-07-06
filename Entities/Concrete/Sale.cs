namespace Entities.Concrete
{
    /// <summary>
    /// Satış işlemleri entitisi
    /// </summary>
    public class Sale : BaseEntity<string>
    {
        public Sale()
        {
            Id = Ulid.NewUlid().ToString();
        }
        /// <summary>
        /// KDV 
        /// </summary>
        public decimal Kdv { get; set; } = default!;

        /// <summary>
        /// Toplam tutarı alanı. 
        /// </summary>
        public decimal TotalPrice { get; set; } = default;

        /// <summary>
        ///Ödeme Şekli
        /// </summary>
        public string PaymentMethod { get; set; } = default!;
        /// <summary>
        ///Masa Numarası Şekli
        /// </summary>
        public string TableNumber { get; set; } = default!;
        /// <summary>
        ///Çalışan Id
        /// </summary>
        public string UserId { get; set; } = default!;
        public User? User { get; set; } 
    }
}