namespace Domain.Models;

/// <summary>
/// Represents a visit to a customer by a visitor to sell products.
/// </summary>
public class Visit
{
    /// <summary>
    /// Gets or sets the unique identifier for the visit.
    /// </summary>
    public int Id { get; set; }

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
    public DateTime VisitDate { get; set; }

    /// <summary>
    /// Gets or sets the purpose of the visit.
    /// </summary>
    public string Purpose { get; set; }

    /// <summary>
    /// Gets or sets any additional notes about the visit.
    /// </summary>
    public string Notes { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Visit"/> class.
    /// </summary>
    /// <param name="customerId">The unique identifier for the customer.</param>
    /// <param name="visitorId">The unique identifier for the visitor.</param>
    /// <param name="visitDate">The date of the visit.</param>
    /// <param name="purpose">The purpose of the visit.</param>
    /// <param name="notes">Any additional notes about the visit.</param>
    public Visit(int customerId, int visitorId, DateTime visitDate, string purpose, string notes)
    {
        CustomerId = customerId;
        VisitorId = visitorId;
        VisitDate = visitDate;
        Purpose = purpose;
        Notes = notes;
    }
}