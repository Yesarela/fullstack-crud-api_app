namespace API_CleanArchitecture.Web.Customer;

public class UpdateCustomerResponse(CustomerRecord customer)
{
  public CustomerRecord Customer { get; set; } = customer;
}
