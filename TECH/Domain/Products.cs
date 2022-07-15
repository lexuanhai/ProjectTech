using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Products")]
    public class Products : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? MarketPrice { get; set; }
        public decimal? ImportPrice { get; set; }
        public DateTime? DateOfManufacture { get; set; }

        // các trường khóa ngoại
        public int? CategoryId { get; set; }
        public int? BandsId { get; set; }        
    }
}
