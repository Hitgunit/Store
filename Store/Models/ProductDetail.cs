using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models
{
    public class ProductDetail : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int? ProdcutId { get; set; }
        public Product? Product { get; set; }
        public string? Material { get; set; }
        public string? Color { get; set; }
        public double? Price { get; set; }
        public bool IsTransient()
        {
            return Id == default(int); //Retornará true si Id es 0, indicando que la entidad es transitoria.
        }
    }
}
