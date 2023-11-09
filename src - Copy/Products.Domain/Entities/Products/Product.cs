using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Domain.Entities.Products
{
    [Table("product")]
    public class Product
    {
        [Key,Required]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("type")]
        public string Type { get; set; } = string.Empty;
        [Column("price")]
        public double Price { get; set; }
        [Column("brand")]
        public string Brand { get; set; } = string.Empty;
        [Column("created_at")]
        public DateTime Created_At { get; set; }
        [Column("updated_at")]
        public DateTime Updated_At { get; set; }
    }
}
