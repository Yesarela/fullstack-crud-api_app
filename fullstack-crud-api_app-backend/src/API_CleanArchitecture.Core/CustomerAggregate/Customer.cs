using System.Xml.Linq;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace API_CleanArchitecture.Core.CustomerAggregate;

 public class Customer(string name, string lastName, string email, string identification, string phone, string address, string gender, DateOnly? birthday) : EntityBase, IAggregateRoot
  {
    public string Name { get; private set; } = Guard.Against.NullOrEmpty(name, nameof(name));
    public string LastName { get; private set; } = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
    public string Email { get; private set; } = Guard.Against.NullOrEmpty(email, nameof(email));
    public string Identification { get; private set; } = Guard.Against.NullOrEmpty(identification, nameof(identification));
    public string Phone { get; private set; } = Guard.Against.NullOrEmpty(phone, nameof(phone));
    public string Address { get; private set; } = Guard.Against.NullOrEmpty(address, nameof(address));
    public string Gender { get; private set; } = Guard.Against.NullOrEmpty(gender, nameof(gender));
    public DateOnly? Birthday { get; private set; } = birthday;
    public DateTime? CreatedDate { get; private set; } = DateTime.Now;
    public DateTime? LastModifiedDate { get; private set; } = DateTime.Now;

  public void UpdateCustomer(string NewName, string NewLastName, string NewEmail, string NewIdentification, string NewPhone, string NewAddress, string NewGender, DateOnly NewBirthday)
  {
    Name = Guard.Against.NullOrEmpty(NewName, nameof(NewName));
    LastName = Guard.Against.NullOrEmpty(NewLastName, nameof(NewLastName));
    Email = Guard.Against.NullOrEmpty(NewEmail, nameof(NewEmail));
    Identification = Guard.Against.NullOrEmpty(NewIdentification, nameof(NewIdentification));
    Phone = Guard.Against.NullOrEmpty(NewPhone, nameof(NewPhone));
    Address = Guard.Against.NullOrEmpty(NewAddress, nameof(NewAddress));
    Gender = Guard.Against.NullOrEmpty(NewGender, nameof(NewGender));
    Birthday = NewBirthday;
    LastModifiedDate = DateTime.Now;
  }
}
