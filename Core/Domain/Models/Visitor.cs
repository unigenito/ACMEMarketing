using Domain.Common;

namespace Domain.Models
{
    public class Visitor: BaseAuditEntity
    {

        /// <summary>
        /// Gets or sets the visitor's name.
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Gets or sets the visitor's last name.
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Gets or sets the visitor's email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the visitor's position.
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Gets or sets the visitor's department.
        /// </summary>
        public string Department { get; set; }
         /// <summary>
        /// Gets or sets the visitor's phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the visits associated with the visitor.
        /// </summary>
        public ICollection<Visit> Visits { get; set; }
    }
}