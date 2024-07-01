using API_CleanArchitecture.Web.Customer;

namespace API_CleanArchitecture.Web.Customer;

public class CustomerListResponse
{
  public List<CustomerRecord> Customer { get; set; } = [];
}
