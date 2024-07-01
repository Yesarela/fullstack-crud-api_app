using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.SmartEnum;

namespace API_CleanArchitecture.Core.CustomerAggregate;

public class CustomerStatus : SmartEnum<CustomerStatus>
{
  public static readonly CustomerStatus CoreTeam = new(nameof(CoreTeam), 1);
  public static readonly CustomerStatus Community = new(nameof(Community), 2);
  public static readonly CustomerStatus NotSet = new(nameof(NotSet), 3);

  protected CustomerStatus(string name, int value) : base(name, value) { }
}
