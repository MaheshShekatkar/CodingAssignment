using BusinessRuleEngine.NotificationHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.Models
{
  public class RegistrationData
  {
    public ICustomer Customer { get; set; }
    
    public Func<string> GetUpdateMessage { get; set; }
  }
}
