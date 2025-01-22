namespace Domain.Models
{
    public class Visitor
    {
        /// <summary>
        /// Gets or sets the visitor's ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the visitor's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the visitor's position.
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Gets or sets the visitor's department.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Gets or sets the visit date.
        /// </summary>
        public DateTime VisitDate { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Visitor"/> class.
        /// </summary>
        /// <param name="id">The visitor's ID.</param>
        /// <param name="name">The visitor's name.</param>
        /// <param name="position">The visitor's position.</param>
        /// <param name="department">The visitor's department.</param>
        /// <param name="visitDate">The visit date.</param>
        public Visitor(int id, string name, string position, string department, DateTime visitDate)
        {
            Id = id;
            Name = name;
            Position = position;
            Department = department;
            VisitDate = visitDate;
        }
    }
}