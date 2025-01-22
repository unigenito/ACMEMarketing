namespace Application.DTOs;

    /// <summary>
    /// Data Transfer Object for Visitor.
    /// </summary>
    public class VisitorDto
    {
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the visitor's name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the visitor's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the visitor's position.
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Gets or sets the visitor's department.
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// Gets or sets the visitor's phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the visit date.
        /// </summary>
        public DateTime LastVisitDate { get; set; }
        /// <summary>
        /// Gets or sets the visit date.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the visitor´s email.
        /// </summary>
        public int TotalVisits { get; set; }
        /// <summary>
        /// Gets or sets the completed visits by the visitor.
        /// </summary>
        public int VisitsCompleted { get; set; }
}