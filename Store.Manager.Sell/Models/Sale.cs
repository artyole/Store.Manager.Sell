using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Manager.Sell.Models
{
    public class Sale
    {
        public int Id { get; set; }
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Column("sale_date")]
        public DateTime SaleDate { get; set; }
        public List<Product> Products { get; set; }

        public Customer Customer { get; set; }
    }
}
