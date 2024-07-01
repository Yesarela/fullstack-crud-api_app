namespace API_CleanArchitecture.Web.Customer;
public record DeleteCustomerRequest
{
  public const string Route = "/Customer/{CustomerId:int}";
  public static string BuildRoute(int customerId) => Route.Replace("{CustomerId:int}", customerId.ToString());

  public int CustomerId { get; set; }
}
