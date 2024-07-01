using System.ComponentModel.DataAnnotations;

namespace API_CleanArchitecture.Web.Customer;

public class UpdateCustomerRequest
{
  public const string Route = "/Customer/{CustomerId:int}";
  public static string BuildRoute(int customerId) => Route.Replace("{CustomerId:int}", customerId.ToString());

  public int CustomerId { get; set; }

  [Required]
  public int Id { get; set; }
  
  [Required]
  public string? Name { get; set; }
  
  [Required]
  public string? LastName { get; set; }

  [Required]
  public string? Email { get; set; }

  [Required]
  public string? Identification { get; set; }

  [Required]

  public string? Phone { get; set; }

  [Required]
  public string? Address {  get; set; }

  [Required]
  public string? Gender { get; set; }

  [Required]
  public DateOnly Birthday { get; set; }

  [Required]
  public DateTime? LastModifiedDate { get; set; } = DateTime.Now;
}
