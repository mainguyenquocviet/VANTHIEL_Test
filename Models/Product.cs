﻿using ShoppingCart.Infrastructure.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models 
{
    public class Product : IValidatableObject
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Please enter a value")]
        public string Name { get; set; }

        public string Slug { get; set; }

        [Required, MinLength(4, ErrorMessage = "Minimum length is 2")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a value")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "You must choose a category")]
        public long CategoryId { get; set; }

        public Category Category { get; set; }

        public string Image { get; set; } = "noimage.png";

        [Required, Range(1, int.MaxValue, ErrorMessage = "Please enter a value")]
        public long TotalAmount { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Please enter a value")]
        public long TotalAvailable { get; set; }

        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TotalAvailable > TotalAmount)
            {
                yield return new ValidationResult("Total Available can not larger than Total Amount", new[] { "TotalAvailable" });
            }
        }
    }
}
