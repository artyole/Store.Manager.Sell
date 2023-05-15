using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Manager.Sell.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)] 
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")] // Validar decimal com duas casas após a vírgula
        public decimal Price { get; set; }

        [StringLength(255)] 
        public string Description { get; set; }

        [Column("sale_id")]
        public int? SaleId { get; set; }

    }
}
