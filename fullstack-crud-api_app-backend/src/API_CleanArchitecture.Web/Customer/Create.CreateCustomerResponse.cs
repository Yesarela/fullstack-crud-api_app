namespace API_CleanArchitecture.Web.Customer;

public class CreateCustomerResponse(int id, string Name, string LastName, string Email, string Identification, string Phone, string Address, string Gender, DateOnly? Birthday, DateTime? CreatedDate, DateTime? LastModifiedDate)
{
  public int Id { get; set; } = id;
  public string Name { get; set; } = Name;
  public string LastName { get; set; } = LastName;
  public string Email { get; set; } = Email; 
  public string Identification { get; set; } = Identification;
  public string Phone { get; set; } = Phone; 
  public string Address { get; set; } = Address; 
  public string Gender { get; set; } = Gender; 
  public DateOnly? Birthday { get; set; } = Birthday;
  public DateTime? CreatedDate { get; set; } = CreatedDate;
  public DateTime? LastModifiedDate { get; set; } = LastModifiedDate;
}
