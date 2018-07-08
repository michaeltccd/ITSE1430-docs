/*
 * ITSE 1430
 * Classwork
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nile.Web.Mvc.Models
{
    /// <summary>Provides information about a product.</summary>
    public class ProductModel
    {   
        public int Id { get; set; }

        public string Description { get; set; }

        [Required(AllowEmptyStrings = false)]     
        public string Name { get; set; }
        
        [Range(0, Double.MaxValue, ErrorMessage = "Price must be >= 0")]
        public decimal Price { get; set; }

        public bool IsDiscontinued { get; set; }
    }
}
