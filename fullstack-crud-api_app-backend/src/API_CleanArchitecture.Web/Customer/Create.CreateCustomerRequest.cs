using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Utilities;

namespace API_CleanArchitecture.Web.Customer;

public class CreateCustomerRequest
{
  public const string Route = "/Customer";

  [Required]
  public string? Name { get; set; }
  public string? LastName { get; set; }
  public string? Email { get; set; }
  public string? Identification { get; set; }
  public string? Phone { get; set; }
  public string? Address { get; set; }
  public string? Gender { get; set; }
  public DateOnly? Birthday { get; set; }
  public DateTime? CreatedDate { get; set; }
  public DateTime? LastModifiedDate { get; set; }
}
