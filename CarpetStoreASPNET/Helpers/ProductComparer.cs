using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CarpetStoreASPNET.Models;

namespace CarpetStoreASPNET.Helpers
{
    public class ProductComparer : IEqualityComparer<Product>
    {
        public ProductComparer()
        {
        }

        public bool Equals(Product x, Product y)
        {
            if(Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) ||

                Object.ReferenceEquals(y, null))

                return false;

            return x.Id == y.Id;
        }

        public int GetHashCode(Product obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 0;
            return obj.Id.GetHashCode();
        }
    }
}
