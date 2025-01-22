using Domain.Common;

namespace Domain.Models
{
    /// <summary>
    /// Represents a customer in the system.
    /// </summary>
    public class Customer: BaseAuditEntity
    {

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
        /// Gets or sets the visits associated with the customer.
        /// </summary>
        public ICollection<Visit> Visits { get; set; }

         /// <summary>
        /// Gets or sets the address of the customer.
        /// </summary>
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
    }
}