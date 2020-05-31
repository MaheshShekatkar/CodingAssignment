using BusinessRuleEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.NotificationHandler
{
  public interface ICutomerNotifier
  {
    void Register(RegistrationData registrationData);

    void Remove(int Id);

    void Notify();
  }
}
