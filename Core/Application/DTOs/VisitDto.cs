namespace Application.DTOs;

/// <summary>
    /// Data Transfer Object for Visit.
    /// </summary>
    public class VisitDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the visit.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the customer.
        /// </summary>
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } 

        /// <summary>
        /// Gets or sets the unique identifier for the visitor.
        /// </summary>
        public int VisitorId { get; set; }
        public string VisitorName { get; set; }

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

        public DateTime? VisitedDate { get; set; }
    }