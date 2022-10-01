using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Data.Models
{
    [Comment("Products to sell.")]
    public class Product
    {
        [Key]
        [Comment("Primary key")]

        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Comment("Product name")]

        public string Name { get; set; }

        [Required]
        [Comment("Products price")]

        public decimal Price { get; set; }

        [Required]
        [Comment("Products quantity")]

        public int Quantity { get; set; }

        [Comment("Product is active")]
        public bool IsActive { get; set; } = true;

    }
}
