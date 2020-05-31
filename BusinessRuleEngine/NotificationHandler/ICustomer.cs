using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.NotificationHandler
{
  public interface ICustomer
  {
    int Id { get; set; }

    string Name { get; set; }

    string Address { get; set; }

    void Update(string message);
  }
}
