using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpetStoreASPNET.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public string Article { get; set; }

        public string Description { get; set; }

        public string Collection { get; set; }

        public string Country { get; set; }

        public string ProdMethod { get; set; }

        public string Material { get; set; }

        public string PileHeight { get; set; }

        public string Density { get; set; }

        public string Shape { get; set; }

        public string Pattern { get; set; }

        public string Style { get; set; }

        public int AmountOfColors { get; set; }

        public int AmountOfInvoices { get; set; }

        public string PrimaryColor { get; set; }

        public List<string> Photos { get; set; } = new List<string>();

        public List<SizeAndPrice> SizesAndPrices { get; set; } = new List<SizeAndPrice>();
    }
}
