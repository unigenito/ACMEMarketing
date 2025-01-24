using Domain.Common;

namespace Domain.Models
{
    /// <summary>
    /// Represents a customer in the system.
    /// </summary>
    public class Customer: BaseAuditEntity
    {
        /// <summary>
        /// Gets or sets the identification DNI/Passport of the customer.
        /// </summary>
        public string Identification { get; set; }
        /// <summary>
        /// Gets or sets the first name of the customer.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the customer.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the genere of the customer.
        /// </summary>
        public string Genere { get; set; }

        /// <summary>
        /// Gets or sets the email address of the customer.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the customer.
        /// </summary>
        public string PhoneNumber { get; set; }
        
        // <summary>
        /// Gets or sets the country of the customer.
        /// </summary>
        public string Country { get; set; }

         /// <summary>
        /// Gets or sets the street of the customer.
        /// </summary>
        public string Street { get; set; }
        // <summary>
        /// Gets or sets the zipcode of the customer.
        /// </summary>
        public string ZipCode { get; set; }
        // <summary>
        /// Gets or sets the city of the customer.
        /// </summary>
        public string City { get; set; }
        // <summary>
        /// Set if the customer is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Gets or sets the visits associated with the customer.
        /// </summary>
        public ICollection<Visit> Visits { get; set; }
    }
}