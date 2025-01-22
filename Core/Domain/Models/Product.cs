namespace Domain.Models
{
    /// <summary>
    /// Represents a product in the system.
    /// </summary>
    public class Product
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="id">The product ID.</param>
        /// <param name="name">The product name.</param>
        /// <param name="description">The product description.</param>
        /// <param name="price">The product price.</param>
        /// <param name="stockQuantity">The stock quantity of the product.</param>
        public Product(int id, string name, string description, decimal price, int stockQuantity)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            StockQuantity = stockQuantity;
        }
    }
}