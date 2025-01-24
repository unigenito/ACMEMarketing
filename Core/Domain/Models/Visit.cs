using Domain.Common;

namespace Domain.Models;

/// <summary>
/// Represents a visit to a customer by a visitor to sell products.
/// </summary>
public class Visit: BaseAuditEntity
{

    /// <summary>
    /// Gets or sets the unique identifier for the customer.
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the visitor.
    /// </summary>
    public int VisitorId { get; set; }

    /// <summary>
    /// Gets or sets the date of the visit.
    /// </summary>
    public DateTime? VisitDate { get; set; }

    /// <summary>
    /// Gets or sets the purpose of the visit.
    /// </summary>
    public string Purpose { get; set; }

    /// <summary>
    /// Gets or sets any additional notes about the visit.
    /// </summary>
    public string Notes { get; set; }

    /// <summary>
        /// Gets or sets the customer associated with the visit.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the visitor associated with the visit.
        /// </summary>
        public Visitor Visitor { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? VisitedDate { get; set; }
}