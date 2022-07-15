using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("ProductImages")]
    public class ProductImages
    {
        [Key]
        public int Id { get; set; }               
        public int? ProductId { get; set; }
        public int? AppImageId { get; set; }
    }
}
