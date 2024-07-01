namespace API_CleanArchitecture.UseCases.Customers;

public record CustomerDTO(int Id, string Name, string LastName, string Email, string Identification, string Phone, string Address, string Gender, DateOnly? Birthday, DateTime? CreatedDate, DateTime? LastModifiedDate);
