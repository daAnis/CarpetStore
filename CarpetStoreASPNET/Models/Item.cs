using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace CarpetStoreASPNET.Models
{
    [NotMapped]
    public class Item
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public SizeAndPrice SizeAndPrice { get; set; }

        public int Quantity { get; set; }
    }
}
