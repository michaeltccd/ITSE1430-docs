using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nile.Web.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0, Double.MaxValue)]
        public decimal Price { get; set; }

        public bool IsDiscontinued { get; set; }
    }
}