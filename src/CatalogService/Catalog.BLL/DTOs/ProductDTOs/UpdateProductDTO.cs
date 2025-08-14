﻿namespace Catalog.BLL.DTOs.ProductDTOs
{
    public record UpdateProductDTO
    {
        public string? Name { get; init; }
        public string? Description { get; init; }
        public decimal? Price { get; init; }
    }
}
