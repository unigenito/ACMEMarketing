namespace Application.DTOs;

/// <summary>
    /// Data Transfer Object for Product.
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the product description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the stock quantity of the product.
        /// </summary>
        public int StockQuantity { get; set; }
    }