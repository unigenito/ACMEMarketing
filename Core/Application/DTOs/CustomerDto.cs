namespace Application.DTOs;

  /// <summary>
    /// Represents a customer in the system.
    /// </summary>
public class CustomerDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Address { get; internal set; }
    public string Street { get; set; }
    public string City { get; internal set; }
    public string ZipCode { get; internal set; }
    public string Phone { get; internal set; }
    public int Pending { get; internal set; }
    public int TotalVisited { get; internal set; }
}