using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nile.Web.Mvc.Models
{
    public static class ProductExtensions
    {
        public static ProductModel ToModel ( this Product source )
                    => new ProductModel() {
                        Id = source.Id,
                        Name = source.Name,
                        Description = source.Description,
                        IsDiscontinued = source.IsDiscontinued,
                        Price = source.Price
                    };

        public static Product ToDomain ( this ProductModel source )
                    => new Product() {
                        Id = source.Id,
                        Name = source.Name,
                        Description = source.Description,
                        IsDiscontinued = source.IsDiscontinued,
                        Price = source.Price
                    };
    }
}