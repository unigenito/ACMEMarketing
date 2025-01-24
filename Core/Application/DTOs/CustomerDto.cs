namespace Application.DTOs;

  /// <summary>
    /// Represents a customer in the system.
    /// </summary>
public class CustomerDto
{
    public int Id { get; set; }
    public string Identification { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Sex { get; set; }
    public string Email { get; set; }
    public string Address { get;  set; }
    public string Country { get; set; }
    public string Street { get; set; }
    public string City { get;  set; }
    public string ZipCode { get;  set; }
    public string Phone { get;  set; }
    public int Pending { get;  set; }
    public int TotalVisited { get;  set; }
}