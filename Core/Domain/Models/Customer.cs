using Domain.Common;

namespace Domain.Models
{
    /// <summary>
    /// Represents a customer in the system.
    /// </summary>
    public class Customer: BaseAuditEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the customer.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the customer.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the customer.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the customer.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the customer.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the date when the customer was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the date when the customer was last updated.
        /// </summary>
        public DateTime UpdatedDate { get; set; }
    }
}