namespace API_CleanArchitecture.Web.Customer;

public record CustomerRecord(int Id, string Name, string LastName, string Email, string Identification, string Phone, string Address, string Gender, DateOnly? Birthday, DateTime? CreatedDate, DateTime? LastModifiedDate);
