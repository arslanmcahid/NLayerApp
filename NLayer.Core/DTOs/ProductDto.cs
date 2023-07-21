﻿namespace NLayer.Core.DTOs
{
    public class ProductDto:BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int Stock { get; set; }

    }
}
